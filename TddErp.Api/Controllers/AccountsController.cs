using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TddErp.Api.Filter;
using TddErp.Api.Infrastructure;
using TddErp.Model.Dto;
using TddErp.Model.InputDto;
using TddErp.Model.Models;
using TddErp.Service.Interface;
using System.Data.Entity;
using AutoMapper;
using TddErp.Model.MutipleDto;

namespace TddErp.Api.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        public AccountsController()
        {
        }

        [RoleAuthorize(Roles = "Admin")]
        [Route("employees")]
        public IHttpActionResult GetEmployees()
        {
            return Ok(this.AppUserManager.Users
                .Select(u => this.TheModelFactory.GetEmployee(u)));
        }

        [RoleAuthorize(Roles="Admin")]
        [Route("members")]
        public IHttpActionResult GetMembers()
        {
            return Ok(this.AppUserManager.Users
                .Select(x => this.TheModelFactory.GetMember(x)));
        }

        [Authorize]
        [Route("employee/{id:guid}")]
        public async Task<IHttpActionResult> GetEmployee(string Id)
        {
            var user = await this.AppUserManager.Users.Include(x=>x.Employee).FirstOrDefaultAsync(x => x.Id==Id);
            if (user != null)
            {
                return Ok(this.TheModelFactory.GetEmployee(user));
            }
            return NotFound();
        }

        [Authorize]
        [Route("employee/{username}")]
        public async Task<IHttpActionResult> GetEmployeeByName(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);
            if (user != null)
            {
                return Ok(this.TheModelFactory.GetEmployee(user));
            }
            return NotFound();
        }

        [Authorize]
        [Route("userIsExist/{username}")]
        public async Task<bool> GetUserByNameIsExist(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(ApplicationUser createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityResult addUserResult = await this.AppUserManager.CreateAsync(createUserModel, createUserModel.PasswordHash);
            var userName = await AppUserManager.FindByNameAsync(createUserModel.UserName);
            addUserResult = await this.AppUserManager.AddToRolesAsync(userName.Id, "Employee");
           
            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }
            return Ok();
        }

        [Authorize]
        [Route("PutPassword")]
        public async Task<IHttpActionResult> PutPassword(UpdatePasswordDto updatePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityResult result = await this.AppUserManager
                .ChangePasswordAsync(updatePasswordDto.Id,
                updatePasswordDto.OldPassword, updatePasswordDto.Password);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
        }

        [Authorize]
        [Route("user")]
        public async Task<IHttpActionResult> PutUser(UpdateEmployeeMutipleDto updateEmployeeMutipleDto)
        {
            var appUser = await this.AppUserManager.FindByIdAsync(updateEmployeeMutipleDto.User.Id);
            if (appUser != null)
            {
                appUser.RocID = updateEmployeeMutipleDto.User.RocID;
                appUser.Email = updateEmployeeMutipleDto.User.Email;
                appUser.PhoneNumber = updateEmployeeMutipleDto.User.PhoneNumber;
                appUser.Address = updateEmployeeMutipleDto.User.Address;
                appUser.Sex = updateEmployeeMutipleDto.User.Sex;
                appUser.Employee.ArriveDate = updateEmployeeMutipleDto.Employee.ArriveDate;
                appUser.Employee.ExitDate = updateEmployeeMutipleDto.Employee.ExitDate;
                IdentityResult result = await this.AppUserManager.UpdateAsync(appUser);
                //string[] roles = this.AppRoleManager.Roles
                //    .Where(x => x.Users.Any(y => y.UserId == updateEmployeeMutipleDto.User.Id) == true)
                //    .Select(x => x.Name).ToArray();
                //result = await this.AppUserManager.RemoveFromRolesAsync(updateEmployeeMutipleDto.User.Id, roles);
                //result = await this.AppUserManager.AddToRolesAsync(updateEmployeeMutipleDto.User.Id, "Member");
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
            }
            return Ok();
        }

        [Authorize]
        [Route("member")]
        public async Task<IHttpActionResult> PutMember(UpdateMemberMutipleDto updateMemberMutipleDto)
        {
            var appUser = await this.AppUserManager.FindByIdAsync(updateMemberMutipleDto.User.Id);
            if (appUser != null)
            {
                appUser.RocID = updateMemberMutipleDto.User.RocID;
                appUser.Email = updateMemberMutipleDto.User.Email;
                appUser.PhoneNumber = updateMemberMutipleDto.User.PhoneNumber;
                appUser.Address = updateMemberMutipleDto.User.Address;
                appUser.Sex = updateMemberMutipleDto.User.Sex;
                appUser.Member.Blog = updateMemberMutipleDto.Member.Blog;
                appUser.Member.JoinDate = updateMemberMutipleDto.Member.JoinDate;
                IdentityResult result = await this.AppUserManager.UpdateAsync(appUser);
               
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
            }
            return Ok();
        }


        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            var appUser = await this.AppUserManager.FindByIdAsync(id);
            var employee = appUser.Employee;
            if (appUser != null)
            {   
                IdentityResult result = this.AppUserManager.Delete(appUser);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
               
                return Ok();
            }
            return NotFound();
        }

        [Route("member/{id:guid}")]
        public async Task<IHttpActionResult> DeleteMember(string id)
        {
            var appUser = await this.AppUserManager.FindByIdAsync(id);
            var member = appUser.Member;
            if (appUser != null)
            {
                IdentityResult result = this.AppUserManager.Delete(appUser);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }
            return NotFound();
        }
    }
}
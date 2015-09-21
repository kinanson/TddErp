using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TddErp.Model.Dto;
using TddErp.Model.InputDto;

namespace TddErp.Api.Controllers
{
    [RoutePrefix("api/roles")]
    public class RolesController : BaseApiController
    {
        [Authorize]
        [Route("{id:guid}", Name = "GetRoleById")]
        public async Task<IHttpActionResult> GetRole(string id)
        {
            var role = await this.AppRoleManager.FindByIdAsync(id);
            if (role != null)
            {
                return Ok(TheModelFactory.Create(role));
            }
            return NotFound();
        }

        [Authorize]
        [Route("GetAllRoles")]
        public IHttpActionResult GetAllRoles()
        {
            var roles = this.AppRoleManager.Roles;
            return Ok(roles);
        }

        [Route("create")]
        public async Task<IHttpActionResult> Create(CreateRoleBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var role = new IdentityRole { Name = model.Name };
            var result = await this.AppRoleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            Uri locationHeader = new Uri(Url.Link("GetRoleById", new { id = role.Id }));
            return Created(locationHeader, TheModelFactory.Create(role));
        }

        [Route("{id:guid}")]
        public async Task<IHttpActionResult> DeleteRole(string id)
        {
            var role = await this.AppRoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await this.AppRoleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                return Ok();
            }
            return NotFound();
        }

        [Route("ManageUsersInRole")]
        public async Task<IHttpActionResult> ManageUsersInRole(UsersInRoleModel model)
        {
            var role = await this.AppRoleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ModelState.AddModelError(string.Empty, "Role does not exist");
                return BadRequest(ModelState);
            }
            foreach (string user in model.EnrolledUsers)
            {
                var appUser = await this.AppUserManager.FindByIdAsync(user);
                if (appUser == null)
                {
                    ModelState.AddModelError(string.Empty, string.Format("User: {0} does not exists", user));
                    continue;
                }
                if (!this.AppUserManager.IsInRole(user, role.Name))
                {
                    IdentityResult result = await this.AppUserManager.AddToRoleAsync(user, role.Name);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, string.Format("User: {0} could not be added to role", user));
                    }
                }
            }
            foreach (string user in model.RemovedUsers)
            {
                var appUser = await this.AppUserManager.FindByIdAsync(user);
                if (appUser == null)
                {
                    ModelState.AddModelError(string.Empty, string.Format("User: {0} does not exists", user));
                    continue;
                }
                IdentityResult result = await this.AppUserManager.RemoveFromRoleAsync(user, role.Name);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, string.Format("User: {0} could not be removed from role", user));
                }
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [Route("user/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {
            var appUser = await this.AppUserManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);
            var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();
            if (rolesNotExists.Count() > 0)
            {
                ModelState.AddModelError(string.Empty, string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }
            IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());
            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Failed to remove user roles");
                return BadRequest(ModelState);
            }
            IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);
            if (!addResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Failed to add user roles");
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
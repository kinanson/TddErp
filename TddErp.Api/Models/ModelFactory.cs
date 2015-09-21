using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using TddErp.Api.Infrastructure;
using TddErp.Api.ViewModel;
using TddErp.Model.Dto;
using TddErp.Model.Models;

namespace TddErp.Api.Models
{
    public class ModelFactory
    {
        private UrlHelper urlHelper;
        private ApplicationUserManager appUserManager;

        public ModelFactory(HttpRequestMessage request, ApplicationUserManager appUserManager)
        {
            urlHelper = new UrlHelper(request);
            this.appUserManager = appUserManager;
        }

        public EmployeeViewModel GetEmployee(ApplicationUser appUser)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            if (appUser.Employee != null)
            {
                var user = new UserDto
                {
                    Id = appUser.Id,
                    Email = appUser.Email,
                    PhoneNumber = appUser.PhoneNumber,
                    LockoutEnabled = appUser.LockoutEnabled,
                    UserName = appUser.UserName,
                    Sex = appUser.Sex,
                    RocID = appUser.RocID,
                    RealName = appUser.RealName,
                    Address = appUser.Address,
                    BirthDate = appUser.BirthDate,
                    Roles = appUserManager.GetRolesAsync(appUser.Id).Result
                };
                employeeViewModel.Employee = new EmployeeDto
                {
                    ArriveDate = appUser.Employee.ArriveDate,
                    ExitDate = appUser.Employee.ExitDate
                };
                employeeViewModel.User = user;
            }
            return employeeViewModel;
        }

        public MemberViewModel GetMember(ApplicationUser appUser)
        {
            MemberViewModel memberViewModel = new MemberViewModel();
            if (appUser.Member != null)
            {
                var user = new UserDto
                {
                    Id = appUser.Id,
                    Email = appUser.Email,
                    PhoneNumber = appUser.PhoneNumber,
                    LockoutEnabled = appUser.LockoutEnabled,
                    UserName = appUser.UserName,
                    Sex = appUser.Sex,
                    RocID = appUser.RocID,
                    RealName = appUser.RealName,
                    Address = appUser.Address,
                    BirthDate = appUser.BirthDate,
                    Roles = appUserManager.GetRolesAsync(appUser.Id).Result
                };
                var member = new MemberDto();
                member.JoinDate = appUser.Member.JoinDate;
                member.Blog = appUser.Member.Blog;
                if (appUser.Member.Hob01) member.Hobby.Add("計算機概論");
                if (appUser.Member.Hob02) member.Hobby.Add("Office系列");
                if (appUser.Member.Hob03) member.Hobby.Add("網頁設計");
                if (appUser.Member.Hob04) member.Hobby.Add("美工繪圖");
                if (appUser.Member.Hob05) member.Hobby.Add("影音剪輯");
                if (appUser.Member.Hob06) member.Hobby.Add("3D與動畫");
                if (appUser.Member.Hob07) member.Hobby.Add("工業與建築");
                if (appUser.Member.Hob08) member.Hobby.Add("作業系統");
                if (appUser.Member.Hob09) member.Hobby.Add("資訊管理");
                if (appUser.Member.Hob10) member.Hobby.Add("電子商務");
                if (appUser.Member.Hob11) member.Hobby.Add("網路設計");
                if (appUser.Member.Hob12) member.Hobby.Add("程式語言");
                if (appUser.Member.Hob13) member.Hobby.Add("遊戲設計");
                if (appUser.Member.Hob14) member.Hobby.Add("資料庫");
                if (appUser.Member.Hob15) member.Hobby.Add("資料結構");
                if (appUser.Member.Hob16) member.Hobby.Add("資料統計");
                if (appUser.Member.Hob17) member.Hobby.Add("單晶片與嵌入式");
                if (appUser.Member.Hob18) member.Hobby.Add("工具軟體");
                memberViewModel.User = user;
                memberViewModel.Member = member;
            }
            return memberViewModel;
        }

        public RoleDto Create(IdentityRole appRole)
        {
            return new RoleDto
            {
                Url = urlHelper.Link("GetRoleById", new { id = appRole.Id }),
                Id = appRole.Id,
                Name = appRole.Name
            }; 
        }
    }
}
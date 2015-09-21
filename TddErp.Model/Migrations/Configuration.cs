namespace TddErp.Model.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TddErp.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TddErp.Model.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TddErp.Model.Models.ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var user = new ApplicationUser()
            {
                UserName = "kinanson",
                Email = "kinanson@gmail.com",
                EmailConfirmed = true,
                RealName = "施文勝",
                Sex = "男",
                BirthDate = Convert.ToDateTime("1982/05/04"),
                RocID = "B122021247",
                PhoneNumber = "0915914666",
                Address = "台中市"
            };
            Employee employee = new Employee { ArriveDate = DateTime.Now };
            user.Employee = employee;
            manager.Create(user, "P@ssw0rd");
            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Employee" });
                roleManager.Create(new IdentityRole { Name = "Member" });
            }
            var kinanson = manager.FindByName("kinanson");
            manager.AddToRoles(kinanson.Id, new string[] { "Admin" });
        }
    }
}
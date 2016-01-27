using MeterAppEntity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MeterAppDal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MeterAppDal.MeterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MeterAppDal.MeterContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MeterContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new MeterContext()));

            var db = new MeterContext();
            var adminUser = new ApplicationUser
            {
                UserName = "adminPower",
                Email = "Admin@1234",
                JoinDate = DateTime.Now,
                FirstName = "Sanuj",
                LastName = "Gandhi",
                Level = 1
            };
            manager.Create(adminUser, "Aspl@1234");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Client" });
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }
            var admin = manager.FindByName("adminPower");

            manager.AddToRoles(adminUser.Id, "Admin");
        }
    }
}
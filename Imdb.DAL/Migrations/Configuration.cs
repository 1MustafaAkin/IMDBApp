namespace Imdb.DAL.Migrations
{
    using Imdb.DATA.Concrete;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Imdb.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Imdb.DAL.Context db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("admin"))
                roleManager.Create(new IdentityRole { Name = "admin" });

            if (!roleManager.RoleExists("premium"))
                roleManager.Create(new IdentityRole { Name = "premium" });

            if (!roleManager.RoleExists("normal"))
                roleManager.Create(new IdentityRole { Name = "normal" });

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var adminUser = userManager.FindByName("admin");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "admin"
                };
                userManager.Create(adminUser, "Mustafa1.");
            }

            if (!userManager.IsInRole(adminUser.Id, "admin"))
                userManager.AddToRole(adminUser.Id, "admin");
        }
    }
}

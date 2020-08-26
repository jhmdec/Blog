namespace Blog.Migrations
{
    using Blog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        ApplicationDbContext context = new ApplicationDbContext();
        List<string> roles = new List<string>(){
                "Admin",
                "Author"

            };

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            CreateRolesAndUsers();

        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Create role Admin and 1 user.
            if (!roleManager.RoleExists("Admin"))
            {

                // Create admin...
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.FirstName = "Admin";
                user.LastName = "Admin";
                user.Email = "admin@nub.se";
                user.UserName = user.Email;
                string pwd = "Abc&123";


                IdentityResult res = userManager.Create(user, pwd);
                if (res.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }
            }

            // Create role Manager and 1 manager...
            if (!roleManager.RoleExists("Author"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Author";
                roleManager.Create(role);


            }
        }
    }
}

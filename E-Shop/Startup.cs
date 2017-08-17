using E_Shop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Shop.Startup))]
namespace E_Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        public void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Nexus";
                user.Email = "lazerx506@gmail.com";

                string userPWD = "litmus90";

                var checkUser = userManager.Create(user, userPWD);

                if (checkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Draconian";
                user.Email = "deanagbemava@live.co.uk";

                string userPWD = "texan879";

                var checkuser = userManager.Create(user, userPWD);

                if (checkuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }
        }
    }
}

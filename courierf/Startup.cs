using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using courierf.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(courierf.Startup))]
namespace courierf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        public void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("BranchManager"))
            {
                var role = new IdentityRole();
                role.Name = "BranchManager";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}

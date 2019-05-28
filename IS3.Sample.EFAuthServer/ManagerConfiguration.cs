using IdentityManager;
using IdentityManager.AspNetIdentity;
using IdentityManager.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.EFAuthServer
{
    public static class ManagerConfiguration
    {
        public static void ConfigureManagerService(this IAppBuilder app)
        {
            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityManagerServiceFactory();

                //IdentityDbContext identityDbContext = new IdentityDbContext("AuthServer");
                IdentityDbContext identityDbContext = new CustomIdentityDbContext("AuthServer");

                UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(identityDbContext));

                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(identityDbContext));

                //var managerService = new AspNetIdentityManagerService<IdentityUser, string, IdentityRole, string>(userManager, roleManager);

                var managerService = new CustomAspNetIdentityManagerService(userManager, roleManager);

                factory.IdentityManagerService = new Registration<IIdentityManagerService>(managerService);

                var managerOptions = new IdentityManagerOptions()
                {
                    Factory = factory
                };

                managerOptions.SecurityConfiguration.RequireSsl = false;

                managerOptions.SecurityConfiguration.AdminRoleName = "admin";//setup which role can manage the account

                adminApp.UseIdentityManager(managerOptions);
            });
        }
    }
}

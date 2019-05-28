using IdentityManager;
using IdentityManager.AspNetIdentity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.EFAuthServer
{
    public class CustomAspNetIdentityManagerService:AspNetIdentityManagerService<IdentityUser,string,IdentityRole,string>
    {
        public CustomAspNetIdentityManagerService(UserManager<IdentityUser, string> userManager, RoleManager<IdentityRole, string> roleManager) : base(userManager, roleManager)
        {

        }

        public override Task<IdentityManagerResult> AddUserClaimAsync(string subject, string type, string value)
        {
            if (type == IdentityManager.Constants.ClaimTypes.Role)
            {
                this.userManager.AddToRole(subject, value);
            }
            return base.AddUserClaimAsync(subject, type, value);
        }

        public override Task<IdentityManagerResult> RemoveUserClaimAsync(string subject, string type, string value)
        {
            if (type == IdentityManager.Constants.ClaimTypes.Role)
            {
                this.userManager.RemoveFromRole(subject, value);
            }

            return base.RemoveUserClaimAsync(subject, type, value);
        }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.EFAuthServer
{
    public class CustomIdentityUser : IdentityUser
    {
        public CustomIdentityUser()
        {

        }

        public CustomIdentityUser(string userName) : base(userName)
        {
        }


    }
}

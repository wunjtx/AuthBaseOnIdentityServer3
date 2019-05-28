using Microsoft.Owin.Security.MicrosoftAccount;
using Microsoft.Owin.Security.QQ;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.EFAuthServer
{
    public static class IdentityProviderManager
    { 
        public static void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            var msOptions = new MicrosoftAccountAuthenticationOptions
            {
                AuthenticationType = "Microsoft",
                SignInAsAuthenticationType = signInAsType,
                ClientId = "myClientId",
                ClientSecret = "mySecret"
            };

            app.UseMicrosoftAccountAuthentication(msOptions);

            var qqOptions = new QQConnectAuthenticationOptions
            {
                AuthenticationType = "QQ",
                SignInAsAuthenticationType = signInAsType,
                AppId = "myClientId",
                AppSecret = "mySecret"
            };

            app.UseQQConnectAuthentication(qqOptions);
        }
    }
}

using System;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.Default;
using IS3.Sample.UserAuthServer.Extens;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IS3.Sample.UserAuthServer.Startup))]

namespace IS3.Sample.UserAuthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new IdentityServerOptions()
            {
                Factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(InMemoryClient.clients)
                .UseInMemoryScopes(InMemoryScope.scopes)
                .UseInMemoryUsers(InMemoryUsers.GetAllUsers()),

                RequireSsl = false,

                AuthenticationOptions=new AuthenticationOptions
                {
                    EnablePostSignOutAutoRedirect=true,
                },

                SigningCertificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(string.Format(@"{0}\certificate\server.pfx",AppDomain.CurrentDomain.BaseDirectory),"4022042"),
            };

            #region customer login css
            //var viewOPtions = new DefaultViewServiceOptions();
            //viewOPtions.CustomViewDirectory = string.Format(@"{0}\Templates\", AppDomain.CurrentDomain.BaseDirectory);
            //viewOPtions.Stylesheets.Add("/Content/Site.css");
            //options.Factory.ConfigureDefaultViewService(viewOPtions); 
            #endregion

            //options.Factory.ClientStore = new Registration<IdentityServer3.Core.Services.IClientStore>(new CustomClientStore());//singleton
            options.Factory.ClientStore = new Registration<IdentityServer3.Core.Services.IClientStore,CustomClientStore>();
            options.Factory.ScopeStore = new Registration<IdentityServer3.Core.Services.IScopeStore,CustomScopeStore>();
            options.Factory.UserService = new Registration<IdentityServer3.Core.Services.IUserService,CustomUserService>();
            app.UseIdentityServer(options);
        }
    }
}

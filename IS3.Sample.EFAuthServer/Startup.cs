using System;
using System.Threading.Tasks;
using IdentityServer3.AspNetIdentity;
using IdentityServer3.Core.Configuration;
using IdentityServer3.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IS3.Sample.EFAuthServer.Startup))]

namespace IS3.Sample.EFAuthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            #region customer login css
            //var viewOPtions = new DefaultViewServiceOptions();
            //viewOPtions.CustomViewDirectory = string.Format(@"{0}\Templates\", AppDomain.CurrentDomain.BaseDirectory);
            //viewOPtions.Stylesheets.Add("/Content/Site.css");
            //options.Factory.ConfigureDefaultViewService(viewOPtions); 
            #endregion

            #region Role Scope EF config

            //ASP.Net identity user role... + identity server3 (EF client scope)

            var efOptions = new EntityFrameworkServiceOptions()
            {
                ConnectionString = "AuthServer",
                Schema=Constants.IdentityServerSchema,
            };

            var factory = new IdentityServerServiceFactory();
            factory.RegisterClientStore(efOptions);
            factory.RegisterScopeStore(efOptions);
            //factory.UseInMemoryUsers(InMemoryUsers.GetAllUsers());
            //factory.UserService = new Registration<IdentityServer3.Core.Services.IUserService>();

            #endregion

            #region User EF config

            //IdentityDbContext identityDbContext = new IdentityDbContext("AuthServer");
            IdentityDbContext identityDbContext = new CustomIdentityDbContext("AuthServer");

            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(identityDbContext));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(identityDbContext));

            var userService = new AspNetIdentityUserService<IdentityUser, string>(userManager);

            factory.UserService = new Registration<IdentityServer3.Core.Services.IUserService>(userService);
            #endregion

            //factory.RegisterConfigurationServices(efOptions);

            #region Token and Cache config

            factory.RegisterOperationalServices(efOptions);//database store token

            factory.ConfigureClientStoreCache();
            factory.ConfigureScopeStoreCache();
            factory.ConfigureUserServiceCache();

            var clearToken = new TokenCleanup(efOptions, 60);
            clearToken.Start();


            #endregion


            #region IdentityServer config

            var options = new IdentityServerOptions()
            {
                Factory = factory,

                RequireSsl = false,

                AuthenticationOptions = new AuthenticationOptions
                {
                    EnablePostSignOutAutoRedirect = true,
                    IdentityProviders = IdentityProviderManager.ConfigureIdentityProviders,
                },

                SigningCertificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(string.Format(@"{0}\certificate\server.pfx", AppDomain.CurrentDomain.BaseDirectory), "4022042"),

            };

            #endregion

            //SampleDataProvider.InitClientAndScopeSampleDatas(efOptions);//init some data

            app.ConfigureManagerService();//for Identity Manager Pages

            app.UseIdentityServer(options);
        }
    }
}

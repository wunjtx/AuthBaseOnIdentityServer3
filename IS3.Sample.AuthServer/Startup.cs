using System;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IS3.Sample.AuthServer.Startup))]

namespace IS3.Sample.AuthServer
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
                .UseInMemoryUsers(new System.Collections.Generic.List<IdentityServer3.Core.Services.InMemory.InMemoryUser>()),
                RequireSsl = false
            };
            app.UseIdentityServer(options);
        }
    }
}

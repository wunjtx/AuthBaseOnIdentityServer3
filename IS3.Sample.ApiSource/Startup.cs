using System;
using System.Threading.Tasks;
using System.Web.Http;
using IS3.Sample.DataAccess;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(IS3.Sample.ApiSource.Startup))]

namespace IS3.Sample.ApiSource
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.CreatePerOwinContext<IBookStroreService>(() =>
                new BookStroreService());

            //1,validate token: IdentityServer3.AccessTokenValidation
            //get validation from the auth server,and set User.Identity.IsAuthenticated = true or false
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions()
            {
                //Authority = "Http://localhost:8002",//for client auth server 
                Authority = "Http://localhost:8003",// for user auth server
                RequiredScopes = new System.Collections.Generic.List<string> { "api1"},
                ValidationMode=IdentityServer3.AccessTokenValidation.ValidationMode.ValidationEndpoint
            });

            //2,validate resource/action: access Thinktecture.IdentityModel.Owin.ResourceAuthorization.WebApi
            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(GetHttpConfig());
            
        }

        private HttpConfiguration GetHttpConfig()
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute
            (
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults:new {id=RouteParameter.Optional}
            );
            //taken the token to the filter, if user auth server do not need set "role"... the auth server will set User.Identity.IsAuthenticated= true or false,
            config.Filters.Add(new AuthorizeAttribute());

            return config;
        }
    }
}

using System;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using Thinktecture.IdentityModel.Client;

[assembly: OwinStartup(typeof(IS3.Sample.WebUser.Startup))]

namespace IS3.Sample.WebUser
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies",
                //CookieDomain="",//for sso
                //CookieHttpOnly=true // for seceret to make js can not get cookie
            });
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                //Authority = "http://localhost:8003",//for user auth server
                Authority = "http://localhost:8008",//for ef auth server
                ClientId = "c-03",
                RequireHttpsMetadata = false,//if not use https
                ClientSecret = "B25F4BF7-8702-4593-BBAA-AD7005C8D4E9",
                RedirectUri = "http://localhost:8004/",
                ResponseType = "id_token token",
                SignInAsAuthenticationType = "Cookies",
                
                Scope = "openid profile api2",//get these authrize token
                //UseTokenLifetime = true,
                
                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    //after Validated,setup cookie
                    SecurityTokenValidated = async n =>
                    {
                        //create userclaim at webclient side
                        //var cookieUser = new ClaimsIdentity(authenticationType: n.AuthenticationTicket.Identity.AuthenticationType,nameType: "role",roleType: "role");
                        var cookieUser = new ClaimsIdentity(authenticationType: n.AuthenticationTicket.Identity.AuthenticationType);
                        //get userinfo from auth server
                        var userInfoUri = new Uri(n.Options.Authority + "/connect/userinfo");
                        var userInfoClient = new UserInfoClient(userInfoUri, n.ProtocolMessage.AccessToken);
                        var userInfo = await userInfoClient.GetAsync();
                        //assign userinfo which from auth server to cookieuser
                        userInfo.Claims.ToList().ForEach(ui => cookieUser.AddClaim( new Claim(ui.Item1, ui.Item2) ));
                        cookieUser.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                        cookieUser.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));
                        //cookieUser.AddClaim(new Claim("refresh_token", n.ProtocolMessage.RefreshToken));
                        n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(cookieUser, n.AuthenticationTicket.Properties);
                    },
                    //logout
                    RedirectToIdentityProvider= r =>
                    {
                        if (r.ProtocolMessage.RequestType==  Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectRequestType.Logout)
                        {
                            var idTokenHint = r.OwinContext.Authentication.User.FindFirst("id_token");
                            if (idTokenHint!=null)
                            {
                                r.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                            }
                        }
                        return Task.FromResult(0);
                    }
                },
            });
            app.UseResourceAuthorization(new AuthorizationManager());
        }
    }
}

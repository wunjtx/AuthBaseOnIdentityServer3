using IdentityServer3.Core.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.UserAuthServer
{
    public class InMemoryClient
    {
        public static ConcurrentBag<Client> clients = new ConcurrentBag<Client>();
        static InMemoryClient()
        {
            clients.Add(new Client()
            {
                ClientId = "c-01",
                ClientName = "client1",
                Flow=Flows.ClientCredentials,
                AccessTokenType=AccessTokenType.Reference,
                ClientSecrets=new List<Secret>
                {
                    new Secret("712C0666-F76C-4673-B19D-369E12A24F38".Sha256())
                },
                Claims=new List<System.Security.Claims.Claim>
                {
                    new System.Security.Claims.Claim("role","role1"),
                    new System.Security.Claims.Claim("access","normal")
                },
                AllowedScopes=new List<string> { "api1","api2"}
                
            });
            clients.Add(new Client()
            {
                ClientId = "c-02",
                ClientName = "client2",
                Flow = Flows.ClientCredentials,
                AccessTokenType = AccessTokenType.Reference,
                ClientSecrets = new List<Secret>
                {
                    new Secret("4E1EA904-2CDD-4E3B-A49A-B688B7C27E1A".Sha256())
                },
                Claims = new List<System.Security.Claims.Claim>
                {
                    new System.Security.Claims.Claim("role","normal"),
                    new System.Security.Claims.Claim("access","normal")
                },
                AllowedScopes = new List<string> { "api1" }

            });
            clients.Add(new Client()
            {
                ClientId = "c-03",
                ClientName = "client3",
                Flow = Flows.Implicit,
                AccessTokenType = AccessTokenType.Jwt,
                ClientSecrets = new List<Secret>
                {
                    new Secret("B25F4BF7-8702-4593-BBAA-AD7005C8D4E9".Sha256())
                },
                Claims = new List<System.Security.Claims.Claim>
                {
                    new System.Security.Claims.Claim("role","normal"),
                    new System.Security.Claims.Claim("role","admin"),
                    new System.Security.Claims.Claim("access","normal")
                },
                AllowedScopes = new List<string> { "api2", "openid","profile" },
                RedirectUris=new List<string>
                {
                    "http://localhost:8004/",
                },
                PostLogoutRedirectUris=new List<string>
                {
                    "http://localhost:8004/",
                }

            });
            clients.Add(new Client()
            {
                ClientId = "c-04",
                ClientName = "client4",
                Flow = Flows.Implicit,
                AccessTokenLifetime = 60,
                AccessTokenType = AccessTokenType.Jwt,
                //ClientSecrets = new List<Secret>
                //{
                //    new Secret("96AACAF2-E449-42FC-8C32-18198DC27706".Sha256())
                //},
                Claims = new List<System.Security.Claims.Claim>
                {
                    new System.Security.Claims.Claim("role","role3"),
                    new System.Security.Claims.Claim("access","normal")
                },
                AllowAccessToAllScopes = true,
                //AllowedScopes = new List<string> { "openid", "profile", "api3", "api1", "roles", "all_claims" },
                RedirectUris = new List<string>
                {
                    "http://localhost:8005/popup.html",
                    "http://localhost:8005/renew.html",
                },
                AllowedCorsOrigins=new List<string>
                {
                    "http://localhost:8005"
                }
            });
            clients.Add(new Client()
            {
                ClientId = "c-05",
                ClientName = "client5",
                Flow = Flows.Implicit,
                AccessTokenLifetime = 60,
                AccessTokenType = AccessTokenType.Jwt,
                ClientSecrets = new List<Secret>
                {
                    new Secret("BCEE3220-1433-45EF-A46A-C042032DD88E".Sha256())
                },

                AllowedScopes = new List<string> { "api1", "openid", "profile", "roles", "api2", "api3" },
                RedirectUris = new List<string>
                {
                    "http://localhost:8006/",
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "http://localhost:8006/",
                }
            });
        }
    }
}

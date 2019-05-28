using IdentityServer3.Core.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.AuthServer
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
        }
    }
}

using IdentityServer3.Core.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.EFAuthServer
{
    public class InMemoryScope
    {
        public static List<Scope> scopes = new List<Scope>();
        static InMemoryScope()
        {
            scopes.Add(
                new Scope
                {
                    Name = "api1",
                    Type=ScopeType.Resource,
                    DisplayName="api1",
                }
            );
            scopes.Add(
                new Scope
                {
                    Name = "api2",
                    Type = ScopeType.Resource,
                    DisplayName = "api2",
                }
            );
            scopes.Add(
                new Scope
                {
                    Name = "api3",
                    Type = ScopeType.Resource,
                    DisplayName = "api3",
                }
            );
            //scopes.Add(
            //    new Scope
            //    {
            //        Name = "openid",
            //        Type = ScopeType.Resource
            //    }
            //);
            //scopes.Add(
            //    new Scope
            //    {
            //        Name = "profile",
            //        Type = ScopeType.Resource
            //    }
            //);
            //scopes.Add(
            //    new Scope
            //    {
            //        Name = "roles",
            //        Type = ScopeType.Identity,
            //        Claims=new List<ScopeClaim> { new ScopeClaim("role")},
            //    }
            //);
            scopes.Add(StandardScopes.OpenId);
            Scope profileScope = StandardScopes.Profile;
            profileScope.IncludeAllClaimsForUser = true;
            scopes.Add(profileScope);
            scopes.Add(StandardScopes.Roles);
            scopes.Add(StandardScopes.AllClaims);
            scopes.Add(StandardScopes.Address);
            scopes.Add(StandardScopes.Email);
            scopes.Add(StandardScopes.Phone);
        }
    }
}

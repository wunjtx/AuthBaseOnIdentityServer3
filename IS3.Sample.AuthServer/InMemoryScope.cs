using IdentityServer3.Core.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.AuthServer
{
    public class InMemoryScope
    {
        public static ConcurrentBag<Scope> scopes = new ConcurrentBag<Scope>();
        static InMemoryScope()
        {
            scopes.Add(
                new Scope
                {
                    Name = "api1"
                }
            );
        }
    }
}

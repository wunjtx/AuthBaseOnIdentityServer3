using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.UserAuthServer
{
    public class InMemoryUsers
    {
        public static List<InMemoryUser> GetAllUsers()
        {
            var users = new List<InMemoryUser>();
            users.Add(
                new InMemoryUser
                {
                    Username = "Sam",
                    Password = "Sam",
                    Subject = "sub-01",
                    
                    Claims = new[]
                    {
                        new Claim("role","AboutGroup"),
                        new Claim("access","normal"),
                    }
                });
            users.Add(
                new InMemoryUser
                {
                    Username = "Ram",
                    Password = "Ram",
                    Subject = "sub-02",
                    Claims = new[]
                    {
                        new Claim("role","AboutGroup"),
                        new Claim("role","ContactGroup"),
                        new Claim("access","normal"),
                    }
                }
                );
            users.Add(
                new InMemoryUser
                {
                    Username = "Tim",
                    Password = "Tim",
                    Subject = "sub-03",
                    Claims = new[]
                    {
                        new Claim("role","ContactGroup"),
                        new Claim("access","normal"),
                    }
                }
                );
            users.Add(
                new InMemoryUser
                {
                    Username = "Tom",
                    Password = "Tom",
                    Subject = "sub-04",
                    Claims = new[]
                    {
                        new Claim("role","ContactGroup"),
                        new Claim("access","normal"),
                    }
                }
                );
            users.Add(
                new InMemoryUser
                {
                    Username = "Aim",
                    Password = "Aim",
                    Subject = "sub-05",
                    Claims = new[]
                    {
                        new Claim("role","ContactGroup"),
                        new Claim("role","AboutGroup"),
                        new Claim("role","AdminGroup"),
                        new Claim("access","normal"),
                    }
                }
                );
            users.Add(
                new InMemoryUser
                {
                    Username = "Dog",
                    Password = "Dog",
                    Subject = "sub-06",
                    Claims = new[]
                    {
                        new Claim("role","DenyGroup"),
                        new Claim("access","Deny"),
                    }
                }
                );
            return users;
        }
    }
}

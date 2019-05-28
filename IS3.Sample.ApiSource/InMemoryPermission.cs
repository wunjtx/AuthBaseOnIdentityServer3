using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.ApiSource
{
    public class InMemoryPermission
    {
        public static ConcurrentBag<Permission> permissions = new ConcurrentBag<Permission>();
        static InMemoryPermission()
        {
            permissions.Add(new Permission
            {
                RoleName="admin",
                ActionName="AllBooks"
            });
            permissions.Add(new Permission
            {
                RoleName="role1",
                ActionName="BookID"
            });
            permissions.Add(new Permission
            {
                RoleName = "role2",
                ResourceName = "Book"
            });
            permissions.Add(new Permission
            {
                RoleName = "role3",
                ResourceName = "Values"
            });
            permissions.Add(new Permission
            {
                RoleName = "denied",
            });
        }
    }
    public class Permission
    {
        public string RoleName { get; set; }
        public string ResourceName { get; set; }
        public string ActionName { get; set; }
    }
}

using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.UserAuthServer.Extens
{
    public class CustomClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult<Client>(InMemoryClient.clients.Single(c => c.ClientId == clientId));
        }
    }
}

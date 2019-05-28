using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace IS3.Sample.ApiSource
{
    public class ValuesController:ApiController
    {
        private static readonly Random random = new Random();
        [ResourceAuthorize("GET", "Values")]
        //[AllowAnonymous]
        public IEnumerable<string> Get()
        {
            var random = new Random();
            return new[]
            {
                random.Next(0,10).ToString(),
                random.Next(0,10).ToString(),
            };
        }
    }
}

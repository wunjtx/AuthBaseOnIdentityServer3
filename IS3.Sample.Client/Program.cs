using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            //test post method

            TokenClient tokenClient1 = new TokenClient("http://localhost:8002/connect/token", "c-01", "712C0666-F76C-4673-B19D-369E12A24F38");
            TokenResponse tokenResponse1 = tokenClient1.RequestClientCredentialsAsync(scope: "api1").Result;
            HttpClient client1 = new HttpClient();
            client1.SetBearerToken(tokenResponse1.AccessToken);

            
            Task<HttpResponseMessage> postResult1 = client1.PostAsync("http://localhost:8001/api/book", new StringContent("test"));
            postResult1.Wait();
            Task<string> reString1 = postResult1.Result.Content.ReadAsStringAsync();
            reString1.Wait();
            //equal this method
            //Console.WriteLine(client.PostAsync("http://localhost:8001/api/book", new StringContent("test")).Result.Content.ReadAsStringAsync().Result);
            Console.WriteLine(reString1.Result);
            Console.WriteLine("#############################################################");
            try
            {
                Console.WriteLine(client1.GetStringAsync("http://localhost:8001/api/book?bookId=1").Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("#############################################################");
            }
            finally {

            //test get method and AllowAnonymous

            TokenClient tokenClient2 = new TokenClient("http://localhost:8002/connect/token", "c-01", "712C0666-F76C-4673-B19D-369E12A24F39");
                //TokenClient tokenClient2 = new TokenClient("http://localhost:8002/connect/token", "c-04");
            TokenResponse tokenResponse2 = tokenClient2.RequestClientCredentialsAsync(scope: "api1").Result;
            HttpClient client2 = new HttpClient();
            client2.SetBearerToken(tokenResponse2.AccessToken);

            Console.WriteLine(client2.GetStringAsync("http://localhost:8001/api/book").Result);
            Console.WriteLine("#############################################################");

            Console.ReadKey();
            }
        }
    }
}

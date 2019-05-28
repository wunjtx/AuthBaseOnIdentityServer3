using Microsoft.Owin.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.UserAuthServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, fileSizeLimitBytes: 1024 * 1024, retainedFileCountLimit: null)
            .CreateLogger();
            using (WebApp.Start<Startup>("Http://localhost:8003"))
            {
                Console.WriteLine(" Http://localhost:8003 User Auth Server Started >.......");
                Console.Read();
            }
        }
    }
}

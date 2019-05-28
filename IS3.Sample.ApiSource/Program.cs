using Microsoft.Owin.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.ApiSource
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("log.txt",
                rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: 1024 * 1024,
                rollOnFileSizeLimit: true)
                .CreateLogger();
            using (WebApp.Start<Startup>("http://localhost:8001"))
            {
                Console.WriteLine("http://localhost:8001 Api Source Started >......");
                Console.Read();
            }
        }
    }
}

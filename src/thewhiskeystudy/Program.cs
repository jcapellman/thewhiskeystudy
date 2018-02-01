using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using NLog.Web;

namespace thewhiskeystudy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog()
                .Build();
    }
}
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using NLog.Web;

namespace thewhiskeystudy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog(lib.Common.Constants.FILE_NLOG_CONFIG_FILENAME).GetCurrentClassLogger();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog()
                .Build();
    }
}
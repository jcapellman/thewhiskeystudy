using System;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using thewhiskeystudy.Models;

namespace thewhiskeystudy.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(IMemoryCache cache, ILogger<HomeController> logger) : base(cache, logger) { }

        [ResponseCache(Duration = Int32.MaxValue)]
        public IActionResult Index() => View();
        
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
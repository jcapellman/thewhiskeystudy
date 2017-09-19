using System;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Models;

namespace thewhiskeystudy.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = Int32.MaxValue)]
        public IActionResult Index() => View();
        
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Models;

namespace thewhiskeystudy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
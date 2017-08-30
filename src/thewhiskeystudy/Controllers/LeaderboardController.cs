using Microsoft.AspNetCore.Mvc;

namespace thewhiskeystudy.Controllers
{
    public class LeaderboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
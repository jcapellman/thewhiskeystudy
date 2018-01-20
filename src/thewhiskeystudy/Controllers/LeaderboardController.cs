using System;

using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Managers;

namespace thewhiskeystudy.Controllers
{
    [ResponseCache(Duration = Int32.MaxValue)]
    public class LeaderboardController : Controller
    {
        public IActionResult Index() => View(new DBManager().GetDatabase());
    }
}
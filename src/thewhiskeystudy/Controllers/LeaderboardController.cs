using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Managers;

namespace thewhiskeystudy.Controllers
{
    public class LeaderboardController : Controller
    {
        public IActionResult Index() => View(new DBManager().GetLeaderboard());
    }
}
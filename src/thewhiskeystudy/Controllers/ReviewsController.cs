using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Managers;

namespace thewhiskeystudy.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index() => View(new DBManager().GetReviewList());
    }
}
using System;

using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Managers;

namespace thewhiskeystudy.Controllers
{
    [ResponseCache(Duration = Int32.MaxValue)]
    public class ReviewsController : Controller
    {
        public IActionResult Index() => View(new DBManager().GetReviewList());
    }
}
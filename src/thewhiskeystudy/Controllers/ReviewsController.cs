using Microsoft.AspNetCore.Mvc;

namespace thewhiskeystudy.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index() => View();
    }
}
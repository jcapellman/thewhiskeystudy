using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Managers;
using thewhiskeystudy.Objects;

namespace thewhiskeystudy.Controllers
{
    [Produces("application/json")]
    [Route("api/API")]
    public class APIController : Controller
    {
        public async void AddReview(ReviewCreationRequestItem requestItem)
        {
            var db = new DBManager();

            await db.AddReviewAsync(requestItem);
        }
    }
}
using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Managers;
using thewhiskeystudy.Objects;

namespace thewhiskeystudy.Controllers
{
    [Produces("application/json")]
    [Route("api/API")]
    public class APIController : Controller
    {
        public void AddReview(ReviewCreationRequestItem requestItem)
        {
            var db = new DBManager();

            db.AddReview(requestItem);
        }
    }
}
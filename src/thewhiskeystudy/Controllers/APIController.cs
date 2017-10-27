using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.Managers;
using thewhiskeystudy.Objects;

namespace thewhiskeystudy.Controllers
{
    [Produces("application/json")]
    [Route("api/API")]
    public class APIController : Controller
    {
        public async Task<bool> AddReview(ReviewCreationRequestItem requestItem)
        {
            var db = new DBManager();

            return await db.AddReviewAsync(requestItem);
        }
    }
}
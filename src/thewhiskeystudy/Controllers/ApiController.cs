using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using thewhiskeystudy.Managers;
using thewhiskeystudy.Middleware;

namespace thewhiskeystudy.Controllers
{
    public class ApiController : BaseController<ApiController>
    {
        public ApiController(IMemoryCache cache, ILogger<ApiController> logger) : base(cache, logger) { }

        [TokenFilter]
        [HttpPut]
        public bool PUT(string jsonDb)
        {
            var (success, exception) = new DBManager(cache).UpdateDatabase(jsonDb);

            if (success)
            {
                return true;
            }

            logger.LogError(exception.ToString());

            return false;
        }
    }
}
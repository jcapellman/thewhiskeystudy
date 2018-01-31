using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using thewhiskeystudy.Managers;
using thewhiskeystudy.Middleware;

namespace thewhiskeystudy.Controllers
{
    public class ApiController : Controller
    {
        private IMemoryCache cache;

        public ApiController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [TokenFilter]
        [HttpPut]
        public bool PUT(string jsonDb) => new DBManager(cache).UpdateDatabase(jsonDb);
    }
}
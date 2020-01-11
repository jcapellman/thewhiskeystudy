using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace thewhiskeystudy.web.Controllers
{
    public class BaseController<T> : Controller
    {
        protected ILogger<T> logger;
        protected IMemoryCache cache;

        public BaseController(IMemoryCache cache, ILogger<T> logger)
        {
            this.logger = logger;
            this.cache = cache;
        }

        public ActionResult RedirectToError(Exception ex)
        {
            logger.LogError(ex, string.Empty, null);

            return View("Error");
        }
    }
}
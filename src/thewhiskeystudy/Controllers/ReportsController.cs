using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using thewhiskeystudy.Reports;

namespace thewhiskeystudy.Controllers
{
    public class ReportsController : BaseController<ReportsController>
    {
        public ReportsController(ILogger<ReportsController> logger, IMemoryCache cache) : base(cache, logger) { }

        private IActionResult RenderReport(BaseReport report)
        {
            var (result, exception) = report.GenerateModel(cache);

            return exception != null ? RedirectToError(exception) : View("Index", result);
        }

        public IActionResult TopRated() => RenderReport(new TopRatedReport());

        public IActionResult TopBargains() => RenderReport(new TopBargainsReport());
    }
}
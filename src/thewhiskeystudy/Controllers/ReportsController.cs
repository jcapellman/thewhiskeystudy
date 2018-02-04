using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using thewhiskeystudy.lib.Objects;

using thewhiskeystudy.Managers;
using thewhiskeystudy.Models;

namespace thewhiskeystudy.Controllers
{
    public class ReportsController : BaseController<ReportsController>
    {
        public ReportsController(ILogger<ReportsController> logger, IMemoryCache cache) : base(cache, logger) { }
        
        public IActionResult TopRated()
        {
            var (result, exception) = new DBManager(cache).GetSuggestions(lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.SuggestionFormChoices.NO_OPINION, null,
                lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.SuggestionFormChoices.NO_OPINION);

            if (exception != null)
            {
                return RedirectToError(exception);
            }

            var model = new ReportModel
            {
                ReportName = lib.Common.Constants.REPORT_NAME_TOP_RATED,
                PageTitle = lib.Common.Constants.REPORT_NAME_TOP_RATED,

                Suggestions = result.Where(a => a.Rating > 8).Select(a => new SuggestionModelItem
                {
                    Name = a.Name,
                    EasyToFind = a.EasyToFind,
                    TastingNotes = a.TastingNotes,
                    Nose = a.Nose,
                    Price = a.Price,
                    AdditionalNotes = a.AdditionalNotes,
                    Aged = a.Aged,
                    ABV = a.ABV,
                    WorthIt = a.WorthIt,
                    Rating = a.Rating,
                    ActualPrice = a.ActualPrice,
                    MaxWorthItPrice = a.MaxWorthItPrice
                }).OrderByDescending(a => a.Rating).ToList()
            };

            return View("Index", model);
        }

        public IActionResult TopBargains()
        {
            var (result, exception) = new DBManager(cache).GetSuggestions(lib.Enums.SuggestionFormChoices.YES, lib.Enums.SuggestionFormChoices.NO_OPINION, 
                lib.Enums.SuggestionFormChoices.NO_OPINION, 60, 
                lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION, 
                lib.Enums.SuggestionFormChoices.NO_OPINION);

            if (exception != null)
            {
                return RedirectToError(exception);
            }

            var model = new ReportModel
            {
                ReportName = lib.Common.Constants.REPORT_NAME_TOP_BARGAINS,
                PageTitle = lib.Common.Constants.REPORT_NAME_TOP_BARGAINS,

                Suggestions = result.Where(a => a.Rating > 5).Select(a => new SuggestionModelItem
                {
                    Name = a.Name,
                    EasyToFind = a.EasyToFind,
                    TastingNotes = a.TastingNotes,
                    Nose = a.Nose,
                    Price = a.Price,
                    AdditionalNotes = a.AdditionalNotes,
                    Aged = a.Aged,
                    ABV = a.ABV,
                    WorthIt = a.WorthIt,
                    Rating = a.Rating,
                    ActualPrice = a.ActualPrice,
                    MaxWorthItPrice = a.MaxWorthItPrice
                }).OrderByDescending(a => a.Rating).ToList()
            };

            return View("Index", model);
        }
    }
}
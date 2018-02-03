using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using thewhiskeystudy.lib.Objects;
using thewhiskeystudy.Managers;
using thewhiskeystudy.Models;

namespace thewhiskeystudy.Controllers
{
    public class ReportsController : Controller
    {
        private IMemoryCache cache;

        private readonly ILogger<ReportsController> logger;

        public ReportsController(ILogger<ReportsController> logger, IMemoryCache cache)
        {
            this.logger = logger;
            this.cache = cache;
        }

        public IActionResult TopRated()
        {
            var results = new DBManager(cache).GetSuggestions(lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.SuggestionFormChoices.NO_OPINION, null,
                lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.SuggestionFormChoices.NO_OPINION);

            var model = new ReportModel
            {
                ReportName = "Top Rated",
                PageTitle = "Top Rated",

                Suggestions = results.Where(a => a.Rating > 8).Select(a => new SuggestionModelItem
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
            var results = new DBManager(cache).GetSuggestions(lib.Enums.SuggestionFormChoices.YES, lib.Enums.SuggestionFormChoices.NO_OPINION, 
                lib.Enums.SuggestionFormChoices.NO_OPINION, 60, 
                lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION, 
                lib.Enums.SuggestionFormChoices.NO_OPINION);

            var model = new ReportModel
            {
                ReportName = "Top Bargains",
                PageTitle = "Top Bargains",

                Suggestions = results.Where(a => a.Rating > 5).Select(a => new SuggestionModelItem
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
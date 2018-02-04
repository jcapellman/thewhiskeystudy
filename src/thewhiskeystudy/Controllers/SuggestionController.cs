using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using thewhiskeystudy.lib.Enums;
using thewhiskeystudy.lib.Objects;

using thewhiskeystudy.Managers;
using thewhiskeystudy.Models;

namespace thewhiskeystudy.Controllers
{
    public class SuggestionController : BaseController<SuggestionController>
    {
        public SuggestionController(IMemoryCache cache, ILogger<SuggestionController> logger) : base(cache, logger) { }
    
        public ActionResult Index(SuggestionFormModel model)
        {
            var (result, exception) = new DBManager(cache).GetSuggestions(model.WantsReadilyAvailable, model.LikesCaramel, model.LikesRye,
                model.MaxPrice, model.LikesHighProof, model.LikesSmooth, model.LikesSweet);

            if (exception != null)
            {
                return RedirectToError(exception);
            }

            var finalResults = result.Select(a => new SuggestionModelItem
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
            });

            if (model.MostImportantAspect == MostImportantSuggestionChoices.NO_OPINION)
            {
                return View(finalResults.ToList());    
            }
                
            switch (model.MostImportantAspect)
            {
                case MostImportantSuggestionChoices.LOW_PRICE:
                    finalResults = finalResults.OrderBy(a => a.Price);
                    break;
                case MostImportantSuggestionChoices.QUALITY:
                    finalResults = finalResults.OrderByDescending(a => a.Rating);
                    break;
            }
            
            return View(finalResults.ToList());
        }
    }
}
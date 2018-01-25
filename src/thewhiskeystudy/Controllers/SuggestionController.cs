using System.Linq;

using Microsoft.AspNetCore.Mvc;

using thewhiskeystudy.lib.Enums;
using thewhiskeystudy.lib.Objects;
using thewhiskeystudy.Managers;
using thewhiskeystudy.Models;

namespace thewhiskeystudy.Controllers
{
    public class SuggestionController : Controller
    {
        public ActionResult Index(SuggestionFormModel model)
        {
            var results = new DBManager().GetSuggestions(model.WantsReadilyAvailable, model.LikesCaramel, model.LikesRye,
                model.MaxPrice, model.LikesHighProof, model.LikesSmooth, model.LikesSweet);

            var finalResults = results.Select(a => new SuggestionModelItem
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
                ActualPrice = a.ActualPrice
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
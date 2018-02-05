using System;
using System.Linq;

using Microsoft.Extensions.Caching.Memory;

using thewhiskeystudy.lib.Objects;
using thewhiskeystudy.Models;

namespace thewhiskeystudy.Reports
{
    public abstract class BaseReport
    {
        protected abstract string ReportName { get; }
        protected abstract string ReportTitle { get; }
        protected abstract string ReportDescription { get; }

        protected abstract (IQueryable<RawDatabaseItem> data, Exception exception) PopulateModel(IMemoryCache cache);

        public (ReportModel model, Exception exception) GenerateModel(IMemoryCache cache)
        {
            var (data, exception) = PopulateModel(cache);

            if (exception != null)
            {
                return (null, exception);
            }

            var model = new ReportModel
            {
                ReportName = ReportName,
                PageTitle = ReportTitle,
                ReportDescription = ReportDescription,
                Suggestions = data.Select(a => new SuggestionModelItem
                {
                    Name = a.Name,
                    DrinkType = a.Type,
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

            return (model, null);
        }
    }
}
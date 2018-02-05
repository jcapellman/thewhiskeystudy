using System;
using System.Linq;

using Microsoft.Extensions.Caching.Memory;

using thewhiskeystudy.lib.Objects;
using thewhiskeystudy.Managers;

namespace thewhiskeystudy.Reports
{
    public class TopBargainsReport : BaseReport
    {
        protected override string ReportName => lib.Common.Constants.REPORT_NAME_TOP_BARGAINS;
        protected override string ReportTitle => lib.Common.Constants.REPORT_NAME_TOP_BARGAINS;
        protected override string ReportDescription => lib.Common.Constants.REPORT_DESCRIPTION_TOP_BARGAINS;

        protected override (IQueryable<RawDatabaseItem> data, Exception exception) populateModel(IMemoryCache cache)
        {
            var (result, exception) = new DBManager(cache).GetSuggestions(lib.Enums.SuggestionFormChoices.YES, lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.SuggestionFormChoices.NO_OPINION, 60,
                lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.DrinkTypeChoices.NO_OPINION);

            if (exception != null)
            {
                return (null, exception);
            }

            return (result.Where(a => a.Rating > 5), null);
        }
    }
}
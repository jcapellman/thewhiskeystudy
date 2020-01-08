using System;
using System.Linq;

using thewhiskeystudy.lib.Objects;
using thewhiskeystudy.web.Managers;

namespace thewhiskeystudy.web.Reports
{
    public class TopRatedReport : BaseReport
    {
        protected override string ReportName => lib.Common.Constants.REPORT_NAME_TOP_RATED;
        protected override string ReportTitle => lib.Common.Constants.REPORT_NAME_TOP_RATED;
        protected override string ReportDescription => lib.Common.Constants.REPORT_DESCRIPTION_TOP_RATED;

        protected override (IQueryable<RawDatabaseItem> data, Exception exception) PopulateModel()
        {
            var (result, exception) = new DBManager().GetSuggestions(lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.SuggestionFormChoices.NO_OPINION, null,
                lib.Enums.SuggestionFormChoices.NO_OPINION, lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.SuggestionFormChoices.NO_OPINION,
                lib.Enums.DrinkTypeChoices.NO_OPINION);

            if (exception != null)
            {
                return (null, exception);
            }

            return (result.Where(a => a.Rating > lib.Common.Constants.TOP_RATED_RATING_CUTOFF), null);
        }
    }
}
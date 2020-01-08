using System.Collections.Generic;

using thewhiskeystudy.lib.Objects;

namespace thewhiskeystudy.web.Data
{
    public class ReportResponseItem
    {
        public List<SuggestionModelItem> Suggestions { get; set; }

        public string PageTitle { get; set; }

        public string ReportName { get; set; }

        public string ReportDescription { get; set; }
    }
}
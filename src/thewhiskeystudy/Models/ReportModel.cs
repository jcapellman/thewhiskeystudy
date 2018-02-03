using System.Collections.Generic;

using thewhiskeystudy.lib.Objects;

namespace thewhiskeystudy.Models
{
    public class ReportModel
    {
        public List<SuggestionModelItem> Suggestions { get; set; }

        public string PageTitle { get; set; }

        public string ReportName { get; set; }
    }
}
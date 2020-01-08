using thewhiskeystudy.web.Reports;

namespace thewhiskeystudy.web.Data
{
    public class ReportsService
    {
        public ReportResponseItem GetReport(BaseReport report)
        {
            var response = report.GenerateModel();

            return response.model;
        }
    }
}
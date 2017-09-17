using thewhiskeystudy.Enums;

namespace thewhiskeystudy.DAL.Tables
{
    public class Reviews : BaseTable
    {
        public string Title { get; set; }
        
        public string URL { get; set; }
        
        public string Body { get; set; }

        public Categories Category { get; set; }

        public double OverallScore { get; set; }

        public int YearReleased { get; set; }

        public Obtainability ObtainabilityStatus { get; set; }

        public double Price { get; set; }
    }
}
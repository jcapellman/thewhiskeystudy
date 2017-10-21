using System.Runtime.Serialization;

using thewhiskeystudy.Enums;

namespace thewhiskeystudy.Objects
{
    [DataContract]
    public class ReviewCreationRequestItem
    {
        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public double OverallScore { get; set; }

        [DataMember]
        public string Title { get; set; }
        
        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int YearReleased { get; set; }

        [DataMember]
        public Categories Category { get; set; }

        [DataMember]
        public Obtainability ObtainabilityStatus { get; set; }
    }
}
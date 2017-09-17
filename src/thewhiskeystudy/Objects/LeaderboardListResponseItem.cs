using System.Runtime.Serialization;

using thewhiskeystudy.DAL.Tables;
using thewhiskeystudy.Enums;

namespace thewhiskeystudy.Objects
{
    public class LeaderboardListResponseItem
    {
        [DataMember]
        public Categories Category { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string URL { get; set; }

        [DataMember]
        public string ThumbnailImage { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public Obtainability ObtainabilityStatus { get; set; }

        [DataMember]
        public double Rating { get; set; }

        public LeaderboardListResponseItem() { }

        public LeaderboardListResponseItem(Reviews review)
        {
            Category = review.Category;
            Name = review.Title;
            URL = review.URL;
            ThumbnailImage = $"{review.Title.ToLower().Replace(" ", "")}.png";
            Price = review.Price;
            ObtainabilityStatus = review.ObtainabilityStatus;
            Rating = review.OverallScore;
        }
    }
}
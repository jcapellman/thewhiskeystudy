using System.Runtime.Serialization;

using thewhiskeystudy.lib.DAL.Tables;
using thewhiskeystudy.lib.Enums;

namespace thewhiskeystudy.lib.Objects
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
        public string Status { get; set; }

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
            Status = review.ObtainabilityStatus.ToString().Replace("_", " ");
            Rating = review.OverallScore;
        }
    }
}
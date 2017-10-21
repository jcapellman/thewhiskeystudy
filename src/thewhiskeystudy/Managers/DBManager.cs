using System.Collections.Generic;
using System.Linq;

using thewhiskeystudy.Objects;
using thewhiskeystudy.DAL;
using thewhiskeystudy.DAL.Tables;

namespace thewhiskeystudy.Managers
{
    public class DBManager : BaseManager
    {
        public List<ReviewListResponseItem> GetReviewList()
        {
            using (var db = new DBFactory())
            {
                return db.SelectMany<Reviews>().Select(b => new ReviewListResponseItem(b)).ToList();
            }
        }

        public List<LeaderboardListResponseItem> GetLeaderboard()
        {
            using (var db = new DBFactory())
            {
                return db.SelectMany<Reviews>().OrderBy(a => a.Category).ThenByDescending(a => a.OverallScore).Select(a => new LeaderboardListResponseItem(a)).ToList();
            }
        }

        public void AddReview(ReviewCreationRequestItem requestItem)
        {
            using (var db = new DBFactory())
            {
                var review = new Reviews
                {
                    Body = requestItem.Body,
                    Category = requestItem.Category,
                    ObtainabilityStatus = requestItem.ObtainabilityStatus,
                    OverallScore = requestItem.OverallScore,
                    Price = requestItem.Price,
                    Title = requestItem.Title,
                    YearReleased = requestItem.YearReleased
                };

                db.Reviews.Add(review);
                db.SaveChanges();
            }
        }
    }
}
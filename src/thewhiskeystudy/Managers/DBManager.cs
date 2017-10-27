﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using thewhiskeystudy.lib.DAL;
using thewhiskeystudy.lib.DAL.Tables;
using thewhiskeystudy.lib.Objects;

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

        public async Task<bool> AddReviewAsync(ReviewCreationRequestItem requestItem)
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

                await db.Reviews.AddAsync(review);

                return await db.SaveChangesAsync() > 0;                
            }
        }
    }
}
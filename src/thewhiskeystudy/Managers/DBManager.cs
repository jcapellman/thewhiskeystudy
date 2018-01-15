using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using CsvHelper;

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
            using (var sr = new StreamReader("Whiskey DB.csv")) { 
                var csv = new CsvReader(sr);

                var records = new List<LeaderboardListResponseItem>();

                while (csv.Read())
                {
                    try
                    {
                        var record = csv.GetRecord<LeaderboardListResponseItem>();

                        records.Add(record);
                    }
                    catch (Exception)
                    {
                    }
                }

                return records;
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
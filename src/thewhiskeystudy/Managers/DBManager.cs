﻿using System.Collections.Generic;
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
    }
}
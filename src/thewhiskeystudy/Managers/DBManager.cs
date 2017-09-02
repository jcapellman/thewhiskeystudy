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
                return db.SelectMany<Reviews>(a => a.Active).Select(b => new ReviewListResponseItem
                {
                    Body = b.Body,
                    Title = b.Title,
                    URL = b.URL
                }).ToList();
            }
        }
    }
}
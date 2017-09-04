using System;
using System.Runtime.Serialization;

using thewhiskeystudy.DAL.Tables;

namespace thewhiskeystudy.Objects
{
    [DataContract]
    public class ReviewListResponseItem
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string URL { get; set; }

        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public DateTime PostDate { get; set; }

        public ReviewListResponseItem() { }

        public ReviewListResponseItem(Reviews review)
        {
            Title = review.Title;
            URL = review.URL;
            Body = review.Body;
            PostDate = review.Created;
        }
    }
}
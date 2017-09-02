using System.Runtime.Serialization;

namespace thewhiskeystudy.Objects
{
    [DataContract]
    public class Reviews
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string URL { get; set; }

        [DataMember]
        public string Body { get; set; }
    }
}
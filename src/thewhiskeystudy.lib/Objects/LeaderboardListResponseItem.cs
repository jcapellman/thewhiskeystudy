using System.Runtime.Serialization;

namespace thewhiskeystudy.lib.Objects
{
    public class LeaderboardListResponseItem
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Aged { get; set; }

        [DataMember]
        public float Rating { get; set; }

        [DataMember]
        public float ABV { get; set; }

        [DataMember]
        public int EaseToFind { get; set; }

        [DataMember]
        public string TastingNotes { get; set; }

        [DataMember]
        public string Nose { get; set; }
        
        [DataMember]
        public string Distillery { get; set; }

        [DataMember]
        public int Price { get; set; }

        public LeaderboardListResponseItem() { }
    }
}
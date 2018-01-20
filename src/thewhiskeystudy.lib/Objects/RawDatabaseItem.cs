using System.Runtime.Serialization;

namespace thewhiskeystudy.lib.Objects
{
    public class RawDatabaseItem
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Aged { get; set; }

        [DataMember]
        public double Rating { get; set; }

        [DataMember]
        public double ABV { get; set; }

        [DataMember]
        public bool EasyToFind { get; set; }

        [DataMember]
        public float EaseToFind { get; set; }

        [DataMember]
        public bool HasSpiceTaste { get; set; }

        [DataMember]
        public bool HasSmoothTaste { get; set; }

        [DataMember]
        public bool HasSweetTaste { get; set; }

        [DataMember]
        public bool HasCaramelTaste { get; set; }

        [DataMember]
        public string TastingNotes { get; set; }

        [DataMember]
        public bool HasCaramelNose { get; set; }

        [DataMember]
        public string Nose { get; set; }
        
        [DataMember]
        public string Distillery { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public bool WorthIt { get; set; }

        [DataMember]
        public int Value { get; set; }

        [DataMember]
        public string AdditionalNotes { get; set; }

        public RawDatabaseItem() { }
    }
}
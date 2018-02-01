using System;
using System.Data;
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
        public double EaseToFind { get; set; }

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

        [DataMember]
        public double? ActualPrice { get; set; }

        [DataMember]
        public double? MaxWorthItPrice { get; set; }

        public RawDatabaseItem() { }

        private const string TRUESTR = "TRUE";

        private bool GetDataRowBool(object objValue) => objValue.ToString().ToUpper() == TRUESTR;
    
        public RawDatabaseItem(DataRow dataRow)
        {
            Name = dataRow[0].ToString();
            Type = dataRow[1].ToString();
            Aged = dataRow[2].ToString();
            Rating = dataRow[3] == DBNull.Value ? 0 : Convert.ToDouble(dataRow[3]);
            ABV = dataRow[4] == DBNull.Value ? 0 : Convert.ToDouble(dataRow[4]);
            EasyToFind = GetDataRowBool(dataRow[5]);
            EaseToFind = dataRow[6] == DBNull.Value ? 0 : Convert.ToDouble(dataRow[6]);
            HasSpiceTaste = GetDataRowBool(dataRow[7]);
            HasSmoothTaste = GetDataRowBool(dataRow[8]);
            HasSweetTaste = GetDataRowBool(dataRow[9]);
            HasCaramelTaste = GetDataRowBool(dataRow[10]);
            TastingNotes = dataRow[11].ToString();
            HasCaramelNose = GetDataRowBool(dataRow[12]);
            Nose = dataRow[13].ToString();
            Distillery = dataRow[14].ToString();
            Price = dataRow[15] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[15]);
            WorthIt = GetDataRowBool(dataRow[16]);
            Value = dataRow[17] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[17]);
            AdditionalNotes = dataRow[18].ToString();
            ActualPrice = dataRow[19] == DBNull.Value ? null : (double?)Convert.ToDouble(dataRow[19]);
            MaxWorthItPrice = dataRow[20] == DBNull.Value ? null : (double?)Convert.ToDouble(dataRow[20]);
        }
    }
}
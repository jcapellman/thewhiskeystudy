using thewhiskeystudy.lib.Enums;

namespace thewhiskeystudy.lib.Objects
{
    public class SuggestionModelItem
    {
        public string Name { get; set; }

        public DrinkTypeChoices DrinkType { get; set; }

        public string Aged { get; set; }

        public double ABV { get; set; }

        public bool EasyToFind { get; set; }

        public string TastingNotes { get; set; }

        public string Nose { get; set; }

        public int Price { get; set; }

        public double Rating { get; set; }

        public bool WorthIt { get; set; }

        public string AdditionalNotes { get; set; }

        public double? ActualPrice { get; set; }

        public double? MaxWorthItPrice { get; set; }
    }
}
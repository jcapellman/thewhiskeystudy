using System.ComponentModel.DataAnnotations;

using thewhiskeystudy.lib.Enums;

namespace thewhiskeystudy.Models
{
    public class SuggestionFormModel
    {
        [Display(Name = "Max Price in USD? (if any)")]
        public double? MaxPrice { get; set; }

        [Display(Name = "Like Rye/Spice Flavor?")]
        public SuggestionFormChoices LikesRye { get; set; }

        [Display(Name = "Like Smoothness?")]
        public SuggestionFormChoices LikesSmooth { get; set; }

        [Display(Name="Like Caramel flavor?")]
        public SuggestionFormChoices LikesCaramel { get; set; }

        [Display(Name="Want it to be easy to find?")]
        public SuggestionFormChoices WantsReadilyAvailable { get; set; }

        [Display(Name = "Like Sweet flavor?")]
        public SuggestionFormChoices LikesSweet { get; set; }  
        
        [Display(Name = "Want it higher proof?")]
        public SuggestionFormChoices LikesHighProof { get; set; }
    }
}
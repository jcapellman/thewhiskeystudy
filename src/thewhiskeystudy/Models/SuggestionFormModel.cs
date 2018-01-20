using System.ComponentModel.DataAnnotations;

namespace thewhiskeystudy.Models
{
    public class SuggestionFormModel
    {
        [Display(Name = "Max Price in USD? (if any)")]
        public double? MaxPrice { get; set; }

        [Display(Name = "Like Rye/Spice Flavor?")]
        public bool LikesRye { get; set; }

        [Display(Name = "Like Smoothness?")]
        public bool LikesSmooth { get; set; }

        [Display(Name="Like Caramel flavor?")]
        public bool LikesCaramel { get; set; }

        [Display(Name="Want it to be easy to find?")]
        public bool WantsReadilyAvailable { get; set; }

        [Display(Name = "Like Sweet flavor?")]
        public bool LikesSweet { get; set; }  
        
        [Display(Name = "Want it higher proof?")]
        public bool LikesHighProof { get; set; }
    }
}
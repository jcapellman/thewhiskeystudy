using System.ComponentModel.DataAnnotations;

namespace thewhiskeystudy.lib.Enums
{
    public enum MostImportantSuggestionChoices
    {
        [Display(Name = "No Opinion")]
        NO_OPINION,
        [Display(Name = "Low Price")]
        LOW_PRICE,
        [Display(Name = "Quality")]
        QUALITY
    }
}
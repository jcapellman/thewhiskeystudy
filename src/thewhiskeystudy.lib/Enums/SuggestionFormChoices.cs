using System.ComponentModel.DataAnnotations;

namespace thewhiskeystudy.lib.Enums
{
    public enum SuggestionFormChoices
    {
        [Display(Name = "No Opinion")]
        NO_OPINION,
        [Display(Name = "Yes")]
        YES,
        [Display(Name = "No")]
        NO
    }
}
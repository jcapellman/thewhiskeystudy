using System.ComponentModel.DataAnnotations;

namespace thewhiskeystudy.lib.Enums
{
    public enum DrinkTypeChoices
    {
        [Display(Name = "No Opinion")]
        NO_OPINION,
        [Display(Name = "Bourbon")]
        BOURBON,
        [Display(Name = "Scotch")]
        SCOTCH,
        [Display(Name = "Whiskey")]
        WHISKEY,
    }
}
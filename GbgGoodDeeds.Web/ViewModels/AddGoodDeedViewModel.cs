using System.ComponentModel.DataAnnotations;

namespace GbgGoodDeeds.Web.ViewModels;

public class AddGoodDeedViewModel
{
    [Required(ErrorMessage = "Titel krävs")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Beskrivning krävs")]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Område (frivilligt)")]
    public string? Neighborhood { get; set; }
}

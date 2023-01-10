using System.ComponentModel.DataAnnotations;

namespace DesignPatternsAPP.Models.ViewModels
{
    public class FormClientViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; } = null!;

        public int? CountryId { get; set; }

        [Display(Name = "Otro Pais")]
        public string OtherCountry { get; set; }
    }
}

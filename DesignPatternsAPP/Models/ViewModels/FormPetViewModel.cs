using System.ComponentModel.DataAnnotations;

namespace DesignPatternsAPP.Models.ViewModels
{
    public class FormPetViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string PetName { get; set; } = null!;
    }
}

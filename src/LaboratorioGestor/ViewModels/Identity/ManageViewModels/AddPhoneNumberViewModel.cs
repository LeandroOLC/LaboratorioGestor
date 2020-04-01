using System.ComponentModel.DataAnnotations;

namespace LaboratorioGestor.App.ViewModels.Identity.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Número de telefone")]
        public string PhoneNumber { get; set; }
    }
}

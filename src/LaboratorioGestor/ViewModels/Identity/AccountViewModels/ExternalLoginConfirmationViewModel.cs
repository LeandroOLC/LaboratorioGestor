using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioGestor.App.ViewModels.Identity.AccountViewModels
{ 
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}

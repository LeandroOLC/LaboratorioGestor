using System.ComponentModel.DataAnnotations;

namespace LaboratorioGestor.App.ViewModels.Identity.ManageViewModels
{ 
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}

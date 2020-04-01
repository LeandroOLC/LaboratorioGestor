using LaboratorioGestor.App.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioGestor.App.ViewModels.Identity.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é requerido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é requerido")]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }

        [Moeda]
        [DisplayName("Comissão")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double PercentualDaComissao { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "A senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}

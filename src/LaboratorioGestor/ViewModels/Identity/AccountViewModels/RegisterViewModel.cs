using LaboratorioGestor.App.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioGestor.App.ViewModels.Identity.AccountViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Nome do Protético")]
        [Required(ErrorMessage = "O Informa {0} é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O Informa {0} é obrigatório")]
        [StringLength(11)]
        public string CPF { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O Informa {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }

        [Moeda]
        [DisplayName("Comissão")]
        [Required(ErrorMessage = "O Informa {0} é obrigatório")]
        public double PercentualDaComissao { get; set; }

        [Required(ErrorMessage = "O Informa {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O Informa {0} é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "A senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}

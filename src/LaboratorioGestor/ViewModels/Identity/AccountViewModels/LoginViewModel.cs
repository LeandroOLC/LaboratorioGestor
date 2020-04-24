using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioGestor.App.ViewModels.Identity.AccountViewModels
{
    public class LoginViewModel
    {
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required]
        [DisplayName("Usuário")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

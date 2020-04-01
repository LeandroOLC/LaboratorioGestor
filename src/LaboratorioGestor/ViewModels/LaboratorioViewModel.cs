using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.ViewModels
{
    public class LaboratorioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }
        public string Documento { get; set; }
        [DisplayName("Proprietário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Proprietario { get; set; }
        public string TPO { get; set; }
        public int TipoPessoa { get; set; }

        [DisplayName("Cadastro")]
        public DateTime? DataDoCadastro { get; set; }
         
        public Guid? IDEndereco { get; set; }
         
        public Guid? IDContato { get; set; }
        public virtual ContatoViewModel Contatos { get; set; }
        public virtual EnderecoViewModel Enderecos { get; set; }
    }
}

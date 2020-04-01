using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.ViewModels
{
    public class DentistaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [DisplayName("Clinica")]
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string NomeDaClinica { get; set; }

        [DisplayName("Cadastro")]
        public DateTime? DataDoCadastro { get; set; }

        [DisplayName("CRO")]
        public string CRO { get; set; }

        [DisplayName("CPF/CNPJ")]
        public string Documento { get; set; }

        [DisplayName("Tipo de documento")]
        public int TipoPessoa { get; set; } 
        public Guid? IDEndereco { get; set; }
        public Guid? IDContato { get; set; }
        public ICollection<ServicoViewModel> Servicos { get; set; }
        public ContatoViewModel Contatos { get; set; }
        public EnderecoViewModel Enderecos { get; set; }

        public SelectList Dentistas()
        {
            return new SelectList(ListarDentista, "Id", "Nome");
        }

        public IEnumerable<DentistaViewModel> ListarDentista { get; set; }

    }
}

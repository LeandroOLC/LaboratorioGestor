using LaboratorioGestor.App.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.ViewModels
{
    public class ProteticoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Moeda]
        [DisplayName("Comissão")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double PercentualDaComissao { get; set; }

        [DisplayName("Cadastro")]
        public DateTime? DataDoCadastro { get; set; }
        public string CPF { get; set; }


        public Guid? IDContato { get; set; }


        public Guid? IDEndereco { get; set; }
        public virtual ContatoViewModel Contatos { get; set; }
        public virtual EnderecoViewModel Enderecos { get; set; }
        public virtual ICollection<ServicoViewModel> Servicos { get; set; }
    }
}

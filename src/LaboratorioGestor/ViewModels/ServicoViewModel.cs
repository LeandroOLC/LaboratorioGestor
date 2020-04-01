using LaboratorioGestor.App.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.ViewModels
{
    public class ServicoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public double? Idade { get; set; }
        public string NomePaciente { get; set; }
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime? DataEntrada { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime? DataEntrega { get; set; }
        public double? ReferenciaOS { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double? Quantidade { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double? Valor { get; set; }
        public string Observcao { get; set; }

        public Guid IDProduto { get; set; }

        public Guid IDProtetico { get; set; }
         
        public Guid IDDentista { get; set; }

        public Guid IDCobranca { get; set; }

        public virtual CobrancaViewModel Cobrancas { get; set; }
        public virtual DentistaViewModel Dentistas { get; set; }
     
        public virtual ProdutoViewModel Produtos { get; set; }
        public virtual ProteticoViewModel Proteticos { get; set; }
    }
}

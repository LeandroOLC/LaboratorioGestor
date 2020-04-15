using LaboratorioGestor.App.Extensions;
using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LaboratorioGestor.App.ViewModels
{
    public class CobrancaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        [Moeda]
        [DisplayName("Desconto")]
        public double? ValorDesconto { get; set; }

        [Moeda]
        [DisplayName("Acrécimo")]
        public double? ValorAcrecimo { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Valor Total")]
        public double? ValorTotal { get; set; }
        public Guid IDDentista { get; set; }

        [Moeda]
        [DisplayName("Haver")]
        public double? ValorRecebimento { get; set; }

        [Moeda]
        [DisplayName("Restante A Pagar")]
        public double? ValorRestante { get; set; }

        [NotMapped]
        public virtual IEnumerable<ServicoViewModel> Servicos { get; set; }
      
        [NotMapped]
        public virtual IEnumerable<RecebimentosViewModel> Recebimentos { get; set; }

        public virtual IPagedList<ServicoViewModel> ServicosPaginado { get; set; }

    }
}

using LaboratorioGestor.App.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.ViewModels
{
    public class RecebimentosViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public int TipoRecebiemnto { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }

        public Guid? IDCobrancas { get; set; }
        
        public Guid IDProtetico { get; set; }

        public virtual CobrancaViewModel Cobrancas { get; set; }
        public virtual ProteticoViewModel ProteticoViewModel { get; set; }
    }
}

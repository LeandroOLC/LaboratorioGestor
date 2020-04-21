using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Recebimentos : Entity
    {
        public DateTime DataCadastro { get; set; }
        public int TipoRecebimento { get; set; }
        public double Valor { get; set; }
        public Guid IDCobranca { get; set; }
        public Guid IDProtetico { get; set; }
        public Cobrancas Cobrancas { get; set; }
        public Proteticos Proteticos { get; set; }
    }
}

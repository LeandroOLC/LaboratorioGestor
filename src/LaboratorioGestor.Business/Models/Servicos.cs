using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Servicos : Entity
    {
        public DateTime DataCadastro { get; set; }
        public double? Idade { get; set; }
        public string NomePaciente { get; set; }
        public string Cor { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double? ReferenciaOS { get; set; }
        public double? Quantidade { get; set; }
        public double? Valor { get; set; }
        public string Observcao { get; set; }
        public Guid IDProduto { get; set; }
        public Guid IDProtetico { get; set; }
        public Guid IDDentista { get; set; }
        public Guid? IDCobranca { get; set; }
        public virtual Cobrancas Cobrancas { get; set; }
        public virtual Dentistas Dentistas { get; set; }
        public virtual Produtos Produtos { get; set; }
        public virtual Proteticos Proteticos { get; set; }
    }
}

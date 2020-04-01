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
        public Guid? IDCobrancas { get; set; }
        public Guid IDUsuarios { get; set; }
        public virtual Cobrancas Cobrancas { get; set; }
    }
}

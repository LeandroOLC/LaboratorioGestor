using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Cobrancas : Entity
    {
        public DateTime DataCadastro { get; set; }

        public double? ValorDesconto { get; set; }

        public double? ValorAcrecimo { get; set; }

        public double? ValorTotal { get; set; }

        public Guid? IDDentista { get; set; }

        public double? ValorRecebimento { get; set; }

        public double? ValorRestante { get; set; }

        public virtual ICollection<Servicos> Servicos { get; set; }

        public virtual ICollection<Recebimentos> Recebimentos { get; set; }
    }
}

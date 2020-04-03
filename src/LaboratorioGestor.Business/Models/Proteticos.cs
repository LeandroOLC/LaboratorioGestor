using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Proteticos : Entity
    {
        public string Nome { get; set; }
        public double PercentualDaComissao { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        public string CPF { get; set; }
        public Guid? IDContato { get; set; }
        public Guid? IDEndereco { get; set; }
        public virtual Contatos Contatos { get; set; }
        public virtual Enderecos Enderecos { get; set; }
        public virtual ICollection<Servicos> Servicos { get; set; }
        public virtual ICollection<Recebimentos> Recebimentos { get; set; }
    }
}

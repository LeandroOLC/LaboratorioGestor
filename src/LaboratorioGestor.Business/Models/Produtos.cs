using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Produtos : Entity
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        public virtual ICollection<Servicos> Servicos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Dentistas : Entity
    {
        public string Nome { get; set; }
        public string NomeDaClinica { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        public string CRO { get; set; }
        public string Documento { get; set; }
        public int TipoPessoa { get; set; }
        public Guid? IDEndereco { get; set; }
        public Guid? IDContato { get; set; }
        public virtual Contatos Contatos { get; set; }
        public virtual Enderecos Enderecos { get; set; }
        public virtual ICollection<Servicos> Servicos { get; set; }

    }
}

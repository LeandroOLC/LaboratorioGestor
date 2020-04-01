using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Enderecos : Entity
    {
        public Guid DentistaId { get; set; }
        public Guid LaboratorioId { get; set; }
        public Guid ProteticoId { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string ReferenciaDoEndereco { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public int TipoEndereco { get; set; }
        public virtual ICollection<Dentistas> Dentistas { get; set; }
        public virtual ICollection<Laboratorios> Laboratorios { get; set; }
        public virtual ICollection<Proteticos> Proteticos { get; set; }

    }
}

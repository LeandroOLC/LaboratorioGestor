using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Contatos : Entity
    {
        public Guid DentistaId { get; set; }
        public Guid LaboratorioId { get; set; }
        public Guid ProteticoId { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular { get; set; }
        public string CelularWhatApp { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public int TipoContato { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Dentistas> Dentistas { get; set; }
        public virtual ICollection<Laboratorios> Laboratorios { get; set; }
        public virtual ICollection<Proteticos> Proteticos { get; set; }

    }
}

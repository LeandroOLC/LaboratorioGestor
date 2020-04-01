using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class Laboratorios : Entity
    {
        public string Nome { get; set; }
        public string Proprietario { get; set; }
        public string TPO { get; set; }
        public string Documento { get; set; }
        public int TipoPessoa { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        public Guid? IDEndereco { get; set; }
        public Guid? IDContato { get; set; }
        public virtual Contatos Contatos { get; set; }
        public virtual Enderecos Enderecos { get; set; }
    }
}

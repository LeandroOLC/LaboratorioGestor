using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Endereço")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Numero { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Bairro { get; set; }

        [StringLength(52, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string UF { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Cidade { get; set; }

        [DisplayName("Referência")]
        public string ReferenciaDoEndereco { get; set; }

        [DisplayName("Cadastrado")]
        public DateTime DataDoCadastro { get; set; }

        public int TipoEndereco { get; set; }

         
        public Guid DentistaId { get; set; }

         
        public Guid LaboratorioId { get; set; }

         
        public Guid ProteticoId { get; set; }
        public virtual ICollection<DentistaViewModel> Dentistas { get; set; }
        public virtual ICollection<LaboratorioViewModel> Laboratorios { get; set; }
        public virtual ICollection<ProteticoViewModel> Proteticos { get; set; }
    }
}

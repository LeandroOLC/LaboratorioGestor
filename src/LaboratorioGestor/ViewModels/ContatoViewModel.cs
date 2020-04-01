using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Fone 1")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 9)]
        public string Fone1 { get; set; }

        [DisplayName("Fone 2")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 9)]
        public string Fone2 { get; set; }

        [DisplayName("Celular")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 9)]
        public string Celular { get; set; }

        [DisplayName("Celular Whatapp")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 9)]       
        public string CelularWhatApp { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public int TipoContato { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Email { get; set; }

         
        public Guid DentistaId { get; set; }

         
        public Guid LaboratorioId { get; set; }

         
        public Guid ProteticoId { get; set; }
        public virtual ICollection<DentistaViewModel> Dentistas { get; set; }
        public virtual ICollection<LaboratorioViewModel> Laboratorios { get; set; }
        public virtual ICollection<ProteticoViewModel> Proteticos { get; set; }
    }
}

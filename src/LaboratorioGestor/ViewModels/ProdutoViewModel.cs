﻿using LaboratorioGestor.App.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }

        [DisplayName("Cadastro")]
        public DateTime? DataDoCadastro { get; set; }

        public virtual ICollection<ServicoViewModel> Servicos { get; set; }

    }
}

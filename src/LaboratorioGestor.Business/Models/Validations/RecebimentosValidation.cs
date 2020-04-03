using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models.Validations
{ 
    public class RecebimentosValidation : AbstractValidator<Recebimentos>
    {
        public RecebimentosValidation()
        {
            RuleFor(c => c.DataCadastro)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
             
            RuleFor(c => c.TipoRecebimento)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Valor)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
    }
}

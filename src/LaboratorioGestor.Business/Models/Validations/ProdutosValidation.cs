using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models.Validations
{
    public class ProdutosValidation : AbstractValidator<Produtos>
    {
        public ProdutosValidation()
        {
            RuleFor(c => c.Nome)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(4, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Valor)
              .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}")
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}

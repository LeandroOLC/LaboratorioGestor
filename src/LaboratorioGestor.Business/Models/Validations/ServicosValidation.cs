using FluentValidation;

namespace LaboratorioGestor.Business.Models.Validations
{
    public class ServicosValidation : AbstractValidator<Servicos>
    {
        public ServicosValidation()
        {
            RuleFor(c => c.IDDentista)
              .NotEmpty().WithMessage("O dentista precisa ser informado");

            RuleFor(c => c.IDProduto)
            .NotEmpty().WithMessage("O produto precisa ser informado");

            RuleFor(c => c.DataEntrada)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Quantidade)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Valor)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}

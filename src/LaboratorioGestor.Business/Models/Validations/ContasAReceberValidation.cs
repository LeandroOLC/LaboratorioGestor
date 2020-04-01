using FluentValidation;


namespace LaboratorioGestor.Business.Models.Validations
{
    public class CobrancasValidation : AbstractValidator<Cobrancas>
    {
        public CobrancasValidation()
        {
            RuleFor(c => c.DataCadastro)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.ValorTotal)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
    }
}

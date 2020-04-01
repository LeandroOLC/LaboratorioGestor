using FluentValidation;

namespace LaboratorioGestor.Business.Models.Validations
{
    public class ContatosValidation : AbstractValidator<Contatos>
    {
        public ContatosValidation()
        {
            RuleFor(c => c.Celular)
              .Length(12, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.CelularWhatApp)
              .Length(12, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Email)
              .Length(10, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Fone1)
              .Length(12, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Fone2)
              .Length(12, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}

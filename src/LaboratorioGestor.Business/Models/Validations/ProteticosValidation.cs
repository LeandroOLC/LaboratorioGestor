using FluentValidation;
using LaboratorioGestor.Business.Models.Validations.Documentos;

namespace LaboratorioGestor.Business.Models.Validations
{
    public class ProteticosValidation : AbstractValidator<Proteticos>
    {
        public ProteticosValidation()
        {
            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(4, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.PercentualDaComissao)
              .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}")
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
              .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
        }
    }
}

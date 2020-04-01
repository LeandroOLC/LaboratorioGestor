using FluentValidation;
using LaboratorioGestor.Business.Models.Validations.Documentos;

namespace LaboratorioGestor.Business.Models.Validations
{
    public class DentistasValidation : AbstractValidator<Dentistas>
    {
        public DentistasValidation()
        {
            RuleFor(c => c.Nome)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .Length(4, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NomeDaClinica)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(4, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.CRO)
               .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => (f.TipoPessoa == 1 && !string.IsNullOrEmpty(f.Documento)), () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                    
                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });

            When(f => (f.TipoPessoa == 2 && !string.IsNullOrEmpty(f.Documento)), () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}

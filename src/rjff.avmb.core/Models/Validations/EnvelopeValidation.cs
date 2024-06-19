using FluentValidation;

namespace rjff.avmb.core.Models.Validations
{
    public class EnvelopeValidation : AbstractValidator<Envelope>
    {
        public EnvelopeValidation()
        {
            RuleFor(c => c.descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}

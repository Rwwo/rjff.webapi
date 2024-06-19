using FluentValidation;

namespace rjff.avmb.core.Models.Validations
{
    public class CriarEnvelopeValidation : AbstractValidator<CriarEnvelope>
    {
        public CriarEnvelopeValidation()
        {
            RuleFor(c => c.Token)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                ;

        }
    }
}

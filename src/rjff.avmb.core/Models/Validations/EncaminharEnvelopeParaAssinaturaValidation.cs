using FluentValidation;

namespace rjff.avmb.core.Models.Validations
{
    public class EncaminharEnvelopeParaAssinaturaValidation : AbstractValidator<EncaminharEnvelopeParaAssinatura>
    {
        public EncaminharEnvelopeParaAssinaturaValidation()
        {
            RuleFor(c => c.token)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                ;

        }
    }
}

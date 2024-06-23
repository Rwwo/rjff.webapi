using FluentValidation;

namespace rjff.avmb.core.Models.Validations
{
    public class DownloadPDFEnvelopeValidation : AbstractValidator<DownloadPDFEnvelope>
    {
        public DownloadPDFEnvelopeValidation()
        {
            RuleFor(c => c.token)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                ;

        }
    }
}

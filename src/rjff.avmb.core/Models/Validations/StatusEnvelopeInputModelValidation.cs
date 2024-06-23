using FluentValidation;

using rjff.avmb.core.InputModels;

namespace rjff.avmb.core.Models.Validations
{
    public class StatusEnvelopeInputModelValidation : AbstractValidator<StatusEnvelopeInputModel>
    {
        public StatusEnvelopeInputModelValidation()
        {
            RuleFor(c => c.token)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                ;

        }
    }
}

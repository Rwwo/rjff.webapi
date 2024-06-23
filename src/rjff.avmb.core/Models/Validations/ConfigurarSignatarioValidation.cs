using FluentValidation;

namespace rjff.avmb.core.Models.Validations
{
    public class ConfigurarSignatarioValidation : AbstractValidator<ConfigurarSignatario>
    {
        public ConfigurarSignatarioValidation()
        {
            RuleFor(c => c.token)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                ;

        }
    }
}

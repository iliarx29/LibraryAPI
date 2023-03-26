using FluentValidation;

namespace Library.Application.Authentication.Commands.Register;
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be empty");
    }
}

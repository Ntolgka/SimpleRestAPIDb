using FluentValidation;
using Week2_Assesment.Models;

namespace Week2_Assesment.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(User => User.Username).NotNull()
            .WithMessage("User Name cannot be null.")
            .Length(1, 10)
            .WithMessage("User name must have a maximum of 10 and a minimum of 1 characters.");

        RuleFor(User => User.Password).NotNull()
            .WithMessage("Password cannot be null.")
            .Length(5, 20)
            .WithMessage("Password must have a maximum of 50 and a minimum of 5 characters.");
    }

}
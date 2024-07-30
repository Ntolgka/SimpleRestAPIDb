using FluentValidation;
using Week2_Assignment.Models;

namespace Week2_Assignment.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Username).NotEmpty()
            .WithMessage("User Name cannot be null.")
            .Length(1, 10)
            .WithMessage("User name must have a maximum of 10 and a minimum of 1 characters.");

        RuleFor(user => user.Password).NotEmpty()
            .WithMessage("Password cannot be null.")
            .Length(5, 20)
            .WithMessage("Password must have a maximum of 50 and a minimum of 5 characters.");
    }

}
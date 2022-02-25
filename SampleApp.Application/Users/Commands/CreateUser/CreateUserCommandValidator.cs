using FluentValidation;

namespace SampleApp.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name can not be empty")
            .MaximumLength(40).WithMessage("Name can not exceed 40 characters");
    }
}


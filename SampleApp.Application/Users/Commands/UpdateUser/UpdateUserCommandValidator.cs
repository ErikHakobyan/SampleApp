using FluentValidation;

namespace SampleApp.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(u => u.Name)
           .NotEmpty().WithMessage("Name can not be empty")
           .MaximumLength(40).WithMessage("Name can not exceed 40 characters");
    }
}


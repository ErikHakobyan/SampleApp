
using FluentValidation;

namespace SampleApp.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotNull()
            .NotEmpty();
    }
}


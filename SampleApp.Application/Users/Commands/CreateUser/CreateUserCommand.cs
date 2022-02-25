using MediatR;
using SampleApp.Application.Common.Interfaces;
using SampleApp.Domain.Entities;
using SampleApp.Domain.Enums;

namespace SampleApp.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Name, int UserType) : IRequest<int>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new User
        {
            Name = request.Name,
            UserType = (UserType)request.UserType
        };
        _context.Users.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}

using MediatR;
using SampleApp.Application.Common.Exceptions;
using SampleApp.Application.Common.Interfaces;
using SampleApp.Domain.Entities;
using SampleApp.Domain.Enums;


namespace SampleApp.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int UserType { get; set; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users
           .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        entity.Name = request.Name;
        entity.UserType = (UserType)request.UserType;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleApp.Application.Common.Exceptions;
using SampleApp.Application.Common.Interfaces;
using SampleApp.Domain.Entities;

namespace SampleApp.Application.Users.Queries.GetUserById;

public record GetUserByIdQuery(int Id) : IRequest<UserDto>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetUserByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<User, UserDto>(await _context.Users
             .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken));
        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        return entity;
    }
}


using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SampleApp.Application.Common.Interfaces;
using SampleApp.Application.Common.Mappings;
using SampleApp.Application.Common.Models;

namespace SampleApp.Application.Users.Queries.GetUsersWithPagination;

public record GetUsersWithPaginationQuery(int PageNumber = 1, int PageSize = 10,string OrderProperty = "Created") : IRequest<PaginatedList<UserDto>>;

public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<UserDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetUsersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<UserDto>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users
            .OrderDescendingDynamic(request.OrderProperty)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}


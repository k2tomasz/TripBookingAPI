using TripBookingAPI.Application.Common.Interfaces;
using TripBookingAPI.Application.Common.Mappings;
using TripBookingAPI.Application.Common.Models;

namespace TripBookingAPI.Application.Trips.Queries.GetTrips;

public record GetTripsWithPaginationQuery : IRequest<PaginatedList<TripDto>>
{
    public string? Country { get; set; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}

public class GetTripsWithPaginationQueryHandler : IRequestHandler<GetTripsWithPaginationQuery, PaginatedList<TripDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTripsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TripDto>> Handle(GetTripsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Trips.AsQueryable();
        if (!string.IsNullOrEmpty(request.Country))
        {
            query = query.Where(x => x.Country.Contains(request.Country));
        }

        return await query.ProjectTo<TripDto>(_mapper.ConfigurationProvider).PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

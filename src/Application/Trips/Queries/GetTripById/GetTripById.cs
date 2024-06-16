using TripBookingAPI.Application.Common.Interfaces;

namespace TripBookingAPI.Application.Trips.Queries.GetTripById;

public record GetTripByIdQuery : IRequest<TripDetailsDto>
{
    public int Id { get; set; }
}

public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, TripDetailsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTripByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TripDetailsDto> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Trips
            .Where(x => x.Id == request.Id)
            .ProjectTo<TripDetailsDto>(_mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken);
    }
}

using TripBookingAPI.Application.Common.Interfaces;
using TripBookingAPI.Domain.Entities;

namespace TripBookingAPI.Application.Trips.Commands.CreateTrip;

public record CreateTripCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public int NumberOfSeats { get; set; }
}

public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTripCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTripCommand request, CancellationToken cancellationToken)
    {
        var trip = new Trip
        {
            Name = request.Name,
            Country = request.Country,
            Description = request.Description,
            StartDate = request.StartDate,
            NumberOfSeats = request.NumberOfSeats
        };

        _context.Trips.Add(trip);
        await _context.SaveChangesAsync(cancellationToken);

        return trip.Id;
    }
}

using TripBookingAPI.Application.Common.Interfaces;

namespace TripBookingAPI.Application.Trips.Commands.UpdateTrip;

public record UpdateTripCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public int NumberOfSeats { get; set; }
}

public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTripCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTripCommand request, CancellationToken cancellationToken)
    {
        var trip = await _context.Trips.FindAsync(request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, trip);

        trip.Name = request.Name;
        trip.Country = request.Country;
        trip.Description = request.Description;
        trip.StartDate = request.StartDate;
        trip.NumberOfSeats = request.NumberOfSeats;

        await _context.SaveChangesAsync(cancellationToken);
    }
}

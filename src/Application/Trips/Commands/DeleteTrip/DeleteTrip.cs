using TripBookingAPI.Application.Common.Interfaces;

namespace TripBookingAPI.Application.Trips.Commands.DeleteTrip;

public record DeleteTripCommand(int Id) : IRequest;

public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTripCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTripCommand request, CancellationToken cancellationToken)
    {
        var trip = await _context.Trips.FindAsync(request.Id);
        
        Guard.Against.NotFound(request.Id, trip);

        _context.Trips.Remove(trip);
        await _context.SaveChangesAsync(cancellationToken);
    }

}

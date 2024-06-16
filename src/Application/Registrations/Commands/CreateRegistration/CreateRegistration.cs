using TripBookingAPI.Application.Common.Interfaces;
using TripBookingAPI.Domain.Entities;

namespace TripBookingAPI.Application.Registrations.Commands.CreateRegistration;

public record CreateRegistrationCommand : IRequest<int>
{
    public int TripId { get; set; }
    public string Email { get; set; } = null!;
}

public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRegistrationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
    {
        var registration = new Registration
        {
            TripId = request.TripId,
            Email = request.Email
        };

        _context.Registrations.Add(registration);
        await _context.SaveChangesAsync(cancellationToken);

        return registration.Id;
    }
}

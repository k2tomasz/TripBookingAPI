using TripBookingAPI.Application.Common.Interfaces;

namespace TripBookingAPI.Application.Trips.Commands.CreateTrip;

public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateTripCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(BeUniqueName)
            .WithMessage("'{PropertyName}' must be unique.")
            .WithErrorCode("Unique");
        RuleFor(x => x.Country).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty().GreaterThan(DateTime.Now);
        RuleFor(x => x.NumberOfSeats).InclusiveBetween(1, 100);
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _context.Trips.AllAsync(l => l.Name != name, cancellationToken);
    }
}

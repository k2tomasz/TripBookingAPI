using TripBookingAPI.Application.Common.Interfaces;

namespace TripBookingAPI.Application.Registrations.Commands.CreateRegistration;

public class CreateRegistrationCommandValidator : AbstractValidator<CreateRegistrationCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateRegistrationCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.TripId).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();

        RuleFor(x => x)
            .MustAsync(async (x, cancellationToken) => await BeUnique(x.TripId, x.Email, cancellationToken))
            .WithMessage("Registration must be unique.")
            .WithErrorCode("Unique");
    }

    public async Task<bool> BeUnique(int tripId, string email, CancellationToken cancellationToken)
    {
        return await _context.Registrations.AnyAsync(r => r.Email == email && r.TripId == tripId, cancellationToken);
    }
}

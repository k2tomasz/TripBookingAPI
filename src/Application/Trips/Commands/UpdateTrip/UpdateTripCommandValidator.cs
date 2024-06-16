namespace TripBookingAPI.Application.Trips.Commands.UpdateTrip;

public class UpdateTripCommandValidator : AbstractValidator<UpdateTripCommand>
{
    public UpdateTripCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Country).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty().GreaterThan(DateTime.Now);
        RuleFor(x => x.NumberOfSeats).InclusiveBetween(1, 100);
    }
}

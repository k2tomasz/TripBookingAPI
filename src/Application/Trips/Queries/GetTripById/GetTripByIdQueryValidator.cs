namespace TripBookingAPI.Application.Trips.Queries.GetTripById;

public class GetTripByIdQueryValidator : AbstractValidator<GetTripByIdQuery>
{
    public GetTripByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
    }
}

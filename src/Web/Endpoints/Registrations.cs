using TripBookingAPI.Application.Registrations.Commands.CreateRegistration;

namespace TripBookingAPI.Web.Endpoints;

public class Registrations : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateRegistration);
    }

    public Task<int> CreateRegistration(ISender sender, CreateRegistrationCommand command)
    {
        return sender.Send(command);
    }
}

using TripBookingAPI.Application.Common.Models;
using TripBookingAPI.Application.Trips.Commands.CreateTrip;
using TripBookingAPI.Application.Trips.Commands.DeleteTrip;
using TripBookingAPI.Application.Trips.Commands.UpdateTrip;
using TripBookingAPI.Application.Trips.Queries.GetTripById;
using TripBookingAPI.Application.Trips.Queries.GetTrips;

namespace TripBookingAPI.Web.Endpoints;

public class Trips : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTripsWithPagination)
            .MapGet(GetTripById, "{id}")
            .MapPost(CreateTrip)
            .MapPut(UpdateTrip, "{id}")
            .MapDelete(DeleteTrip, "{id}");
    }

    public Task<PaginatedList<TripDto>> GetTripsWithPagination(ISender sender, [AsParameters] GetTripsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<TripDetailsDto> GetTripById(ISender sender, [AsParameters] GetTripByIdQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateTrip(ISender sender, CreateTripCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateTrip(ISender sender, int id, UpdateTripCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTrip(ISender sender, int id)
    {
        await sender.Send(new DeleteTripCommand(id));
        return Results.NoContent();
    }
}

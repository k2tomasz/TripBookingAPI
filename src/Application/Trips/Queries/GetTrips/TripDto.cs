using TripBookingAPI.Domain.Entities;

namespace TripBookingAPI.Application.Trips.Queries.GetTrips;

public class TripDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public DateTime StartDate { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Trip, TripDto>();
        }
    }
}

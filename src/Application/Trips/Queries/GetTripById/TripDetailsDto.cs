using TripBookingAPI.Domain.Entities;

namespace TripBookingAPI.Application.Trips.Queries.GetTripById;

public class TripDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public int NumberOfSeats { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Trip, TripDetailsDto>();
        }
    }
}

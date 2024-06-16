namespace TripBookingAPI.Domain.Entities;

public class Trip : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public int NumberOfSeats { get; set; }
}

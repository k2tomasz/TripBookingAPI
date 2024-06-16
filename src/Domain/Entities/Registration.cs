namespace TripBookingAPI.Domain.Entities;

public class Registration : BaseAuditableEntity
{
    public int TripId { get; set; }
    public string Email { get; set; } = null!;
    public virtual Trip Trip { get; set; } = null!;
}

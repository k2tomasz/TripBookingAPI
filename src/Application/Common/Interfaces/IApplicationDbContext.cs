using TripBookingAPI.Domain.Entities;

namespace TripBookingAPI.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Trip> Trips { get; }
    DbSet<Registration> Registrations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

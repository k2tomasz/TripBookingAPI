using TripBookingAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TripBookingAPI.Infrastructure.Data.Configurations;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable("Trips");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Country)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(t => t.Description)
            .IsRequired();

        builder.Property(t => t.StartDate)
            .IsRequired();

        builder.Property(t => t.NumberOfSeats)
            .IsRequired()
            .HasMaxLength(100);
    }
}

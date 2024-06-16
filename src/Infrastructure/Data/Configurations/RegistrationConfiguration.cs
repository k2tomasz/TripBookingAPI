using TripBookingAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TripBookingAPI.Infrastructure.Data.Configurations;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.ToTable("Registrations");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.TripId)
            .IsRequired();

        builder.Property(r => r.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(r => r.Trip)
            .WithMany()
            .HasForeignKey(r => r.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => new { r.TripId, r.Email })
            .IsUnique();
    }
}

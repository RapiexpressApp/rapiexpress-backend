using Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class TrackingEventConfiguration : IEntityTypeConfiguration<TrackingEvent>
{
    public void Configure(EntityTypeBuilder<TrackingEvent> builder)
    {
        builder.HasKey(e => e.Id).HasName("tracking_event_pkey");

        builder.ToTable("tracking_event");

        builder.HasIndex(e => e.CreatedAt, "idx_tracking_event_created");

        builder.HasIndex(e => e.PackageId, "idx_tracking_event_package");

        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
        builder.Property(e => e.CreatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.IsVisibleToCustomer).HasDefaultValue(true).HasColumnName("is_visible_to_customer");
        builder.Property(e => e.Note).HasMaxLength(255).HasColumnName("note");
        builder.Property(e => e.PackageId).HasColumnName("package_id");

        builder.HasOne(d => d.Package)
            .WithMany(p => p.TrackingEvents)
            .HasForeignKey(d => d.PackageId)
            .HasConstraintName("tracking_event_package_id_fkey");
    }
}
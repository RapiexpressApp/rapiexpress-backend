using Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.HasKey(e => e.Id).HasName("package_pkey");

        builder.ToTable("package");

        builder.HasIndex(e => e.CustomerId, "idx_package_customer");

        builder.HasIndex(e => e.ExternalTracking, "idx_package_external_tracking");

        builder.HasIndex(e => e.WarehouseNumber, "idx_package_warehouse_number");

        builder.HasIndex(e => e.WarehouseNumber, "package_warehouse_number_key").IsUnique();

        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
        builder.Property(e => e.CreatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.Currency)
            .HasMaxLength(3)
            .HasDefaultValueSql("'USD'::character varying")
            .HasColumnName("currency");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.CustomsCategoryId).HasColumnName("customs_category_id");
        builder.Property(e => e.DeclaredPurchaseId).HasColumnName("declared_purchase_id");
        builder.Property(e => e.DeclaredValue).HasPrecision(12, 2).HasColumnName("declared_value");
        builder.Property(e => e.Description).HasMaxLength(500).HasColumnName("description");
        builder.Property(e => e.ExternalTracking).HasMaxLength(120).HasColumnName("external_tracking");
        builder.Property(e => e.IsFragile).HasColumnName("is_fragile");
        builder.Property(e => e.IsRepacked).HasColumnName("is_repacked");
        builder.Property(e => e.LockerId).HasColumnName("locker_id");
        builder.Property(e => e.Observations).HasMaxLength(500).HasColumnName("observations");
        builder.Property(e => e.Pieces).HasDefaultValue(1).HasColumnName("pieces");
        builder.Property(e => e.ReceivedAt).HasPrecision(6).HasColumnName("received_at");
        builder.Property(e => e.UpdatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("updated_at");
        builder.Property(e => e.WarehouseNumber).HasMaxLength(60).HasColumnName("warehouse_number");
        builder.Property(e => e.WeightKg).HasPrecision(10, 2).HasColumnName("weight_kg");
        builder.Property(e => e.WeightLb).HasPrecision(10, 2).HasColumnName("weight_lb");

        builder.HasOne(d => d.Customer)
            .WithMany(p => p.Packages)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("package_customer_id_fkey");

        builder.HasOne(d => d.CustomsCategory)
            .WithMany(p => p.Packages)
            .HasForeignKey(d => d.CustomsCategoryId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("package_customs_category_id_fkey");

        builder.HasOne(d => d.DeclaredPurchase)
            .WithMany(p => p.Packages)
            .HasForeignKey(d => d.DeclaredPurchaseId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("package_declared_purchase_id_fkey");

        builder.HasOne(d => d.Locker)
            .WithMany(p => p.Packages)
            .HasForeignKey(d => d.LockerId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("package_locker_id_fkey");
    }
}
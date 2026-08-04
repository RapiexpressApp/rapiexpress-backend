using Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CustomsCategoryConfiguration : IEntityTypeConfiguration<CustomsCategory>
{
    public void Configure(EntityTypeBuilder<CustomsCategory> builder)
    {
        builder.HasKey(e => e.Id).HasName("customs_category_pkey");

        builder.ToTable("customs_category");

        builder.HasIndex(e => e.Code, "customs_category_code_key").IsUnique();

        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
        builder.Property(e => e.Active).HasDefaultValue(true).HasColumnName("active");
        builder.Property(e => e.Code).HasMaxLength(30).HasColumnName("code");
        builder.Property(e => e.CreatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.Currency)
            .HasMaxLength(3)
            .HasDefaultValueSql("'USD'::character varying")
            .HasColumnName("currency");
        builder.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
        builder.Property(e => e.MaxDeclaredValue).HasPrecision(12, 2).HasColumnName("max_declared_value");
        builder.Property(e => e.MaxWeightKg).HasPrecision(10, 2).HasColumnName("max_weight_kg");
        builder.Property(e => e.MaxWeightLb).HasPrecision(10, 2).HasColumnName("max_weight_lb");
        builder.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
        builder.Property(e => e.UpdatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("updated_at");
    }
}
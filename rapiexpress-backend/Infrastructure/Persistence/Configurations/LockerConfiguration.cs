using Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class LockerConfiguration : IEntityTypeConfiguration<Locker>
{
    public void Configure(EntityTypeBuilder<Locker> builder)
    {
        builder.HasKey(e => e.Id).HasName("locker_pkey");

        builder.ToTable("locker");

        builder.HasIndex(e => e.Code, "locker_code_key").IsUnique();

        builder.HasIndex(e => e.CustomerId, "locker_customer_id_key").IsUnique();

        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
        builder.Property(e => e.City)
            .HasMaxLength(80)
            .HasDefaultValueSql("'Hialeah'::character varying")
            .HasColumnName("city");
        builder.Property(e => e.Code).HasMaxLength(40).HasColumnName("code");
        builder.Property(e => e.Country)
            .HasMaxLength(40)
            .HasDefaultValueSql("'USA'::character varying")
            .HasColumnName("country");
        builder.Property(e => e.CreatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.State)
            .HasMaxLength(40)
            .HasDefaultValueSql("'FL'::character varying")
            .HasColumnName("state");
        builder.Property(e => e.UpdatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("updated_at");
        builder.Property(e => e.UsAddressLine).HasMaxLength(200).HasColumnName("us_address_line");
        builder.Property(e => e.ZipCode).HasMaxLength(20).HasColumnName("zip_code");

        builder.HasOne(d => d.Customer)
            .WithOne(p => p.Locker)
            .HasForeignKey<Locker>(d => d.CustomerId)
            .HasConstraintName("locker_customer_id_fkey");
    }
}
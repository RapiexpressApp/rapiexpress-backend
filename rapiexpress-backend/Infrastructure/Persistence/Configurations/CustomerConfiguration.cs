using Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id).HasName("customer_pkey");

        builder.ToTable("customer");

        builder.HasIndex(e => e.AppUserId, "customer_app_user_id_key").IsUnique();

        builder.HasIndex(e => e.AppUserId, "idx_customer_app_user");

        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
        builder.Property(e => e.AppUserId).HasColumnName("app_user_id");
        builder.Property(e => e.BusinessName).HasMaxLength(150).HasColumnName("business_name");
        builder.Property(e => e.CreatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.DocumentId).HasMaxLength(20).HasColumnName("document_id");
        builder.Property(e => e.Notes).HasMaxLength(500).HasColumnName("notes");
        builder.Property(e => e.Phone).HasMaxLength(30).HasColumnName("phone");
        builder.Property(e => e.UpdatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("updated_at");
        builder.Property(e => e.Whatsapp).HasMaxLength(30).HasColumnName("whatsapp");
    }
}
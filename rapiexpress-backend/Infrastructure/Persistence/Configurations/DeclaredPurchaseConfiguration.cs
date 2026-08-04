using Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DeclaredPurchaseConfiguration : IEntityTypeConfiguration<DeclaredPurchase>
{
    public void Configure(EntityTypeBuilder<DeclaredPurchase> builder)
    {
        builder.HasKey(e => e.Id).HasName("declared_purchase_pkey");

        builder.ToTable("declared_purchase");

        builder.HasIndex(e => e.CustomerId, "idx_declared_purchase_customer");

        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
        builder.Property(e => e.CreatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.Currency)
            .HasMaxLength(3)
            .HasDefaultValueSql("'USD'::character varying")
            .HasColumnName("currency");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.CustomsCategoryId).HasColumnName("customs_category_id");
        builder.Property(e => e.DeclaredValue).HasPrecision(12, 2).HasColumnName("declared_value");
        builder.Property(e => e.EstimatedWeightLb).HasPrecision(10, 2).HasColumnName("estimated_weight_lb");
        builder.Property(e => e.ExternalTracking).HasMaxLength(120).HasColumnName("external_tracking");
        builder.Property(e => e.InvoiceAttachmentId).HasColumnName("invoice_attachment_id");
        builder.Property(e => e.ProductDescription).HasMaxLength(500).HasColumnName("product_description");
        builder.Property(e => e.StoreName).HasMaxLength(120).HasColumnName("store_name");
        builder.Property(e => e.UpdatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("updated_at");

        builder.HasOne(d => d.Customer)
            .WithMany(p => p.DeclaredPurchases)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("declared_purchase_customer_id_fkey");

        builder.HasOne(d => d.CustomsCategory)
            .WithMany(p => p.DeclaredPurchases)
            .HasForeignKey(d => d.CustomsCategoryId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("declared_purchase_customs_category_id_fkey");

        builder.HasOne(d => d.InvoiceAttachment)
            .WithMany(p => p.DeclaredPurchases)
            .HasForeignKey(d => d.InvoiceAttachmentId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("declared_purchase_invoice_attachment_id_fkey");
    }
}
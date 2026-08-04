using Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(e => e.Id).HasName("payment_pkey");

        builder.ToTable("payment");

        builder.HasIndex(e => e.CustomerId, "idx_payment_customer");

        builder.HasIndex(e => e.Code, "payment_code_key").IsUnique();

        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
        builder.Property(e => e.Amount).HasPrecision(12, 2).HasColumnName("amount");
        builder.Property(e => e.Code).HasMaxLength(40).HasColumnName("code");
        builder.Property(e => e.CreatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.Currency)
            .HasMaxLength(3)
            .HasDefaultValueSql("'USD'::character varying")
            .HasColumnName("currency");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.ProofAttachmentId).HasColumnName("proof_attachment_id");
        builder.Property(e => e.Reference).HasMaxLength(120).HasColumnName("reference");
        builder.Property(e => e.RejectReason).HasMaxLength(255).HasColumnName("reject_reason");
        builder.Property(e => e.UpdatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("updated_at");
        builder.Property(e => e.ValidatedAt).HasPrecision(6).HasColumnName("validated_at");
        builder.Property(e => e.ValidatedBy).HasColumnName("validated_by");

        builder.HasOne(d => d.Customer)
            .WithMany(p => p.Payments)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("payment_customer_id_fkey");

        builder.HasOne(d => d.ProofAttachment)
            .WithMany(p => p.Payments)
            .HasForeignKey(d => d.ProofAttachmentId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("payment_proof_attachment_id_fkey");
    }
}
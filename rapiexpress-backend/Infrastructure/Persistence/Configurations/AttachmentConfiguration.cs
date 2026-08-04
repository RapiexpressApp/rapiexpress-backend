using Domain.Logistics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public sealed class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.HasKey(e => e.Id).HasName("attachment_pkey");

        builder.ToTable("attachment");

        builder.HasIndex(e => e.PackageId, "idx_attachment_package");

        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()").HasColumnName("id");
        builder.Property(e => e.CreatedAt).HasPrecision(6).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.FileUrl).HasMaxLength(500).HasColumnName("file_url");
        builder.Property(e => e.MimeType).HasMaxLength(120).HasColumnName("mime_type");
        builder.Property(e => e.OriginalName).HasMaxLength(200).HasColumnName("original_name");
        builder.Property(e => e.PackageId).HasColumnName("package_id");
        builder.Property(e => e.SizeBytes).HasColumnName("size_bytes");
        builder.Property(e => e.UploadedBy).HasColumnName("uploaded_by");

        builder.HasOne(d => d.Package)
            .WithMany(p => p.Attachments)
            .HasForeignKey(d => d.PackageId)
            .HasConstraintName("attachment_package_id_fkey");
    }
}
using Domain.Logistics.Enums;

namespace Domain.Logistics.Entities;

public class Attachment
{
    public Guid Id { get; set; }

    public Guid PackageId { get; set; }
    
    public AttachmentType Type { get; set; }

    public string FileUrl { get; set; } = null!;

    public string? OriginalName { get; set; }

    public string? MimeType { get; set; }                                                       

    public long? SizeBytes { get; set; }

    public Guid? UploadedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<DeclaredPurchase> DeclaredPurchases { get; set; } = [];

    public virtual Package Package { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = [];
}

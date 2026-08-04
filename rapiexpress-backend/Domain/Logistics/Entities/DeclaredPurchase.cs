namespace Domain.Logistics.Entities;

public class DeclaredPurchase
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public string StoreName { get; set; } = null!;

    public string? ExternalTracking { get; set; }

    public string ProductDescription { get; set; } = null!;

    public decimal DeclaredValue { get; set; }

    public string Currency { get; set; } = null!;

    public decimal? EstimatedWeightLb { get; set; }

    public Guid CustomsCategoryId { get; set; }

    public Guid InvoiceAttachmentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomsCategory CustomsCategory { get; set; } = null!;

    public virtual Attachment InvoiceAttachment { get; set; } = null!;

    public virtual ICollection<Package> Packages { get; set; } = [];
}

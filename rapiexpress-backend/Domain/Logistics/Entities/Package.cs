using Domain.Logistics.Enums;

namespace Domain.Logistics.Entities;

public class Package
{
    public Guid Id { get; set; }

    public string WarehouseNumber { get; set; } = null!;

    public string? ExternalTracking { get; set; }

    public Guid CustomerId { get; set; }

    public Guid LockerId { get; set; }

    public Guid CustomsCategoryId { get; set; }

    public Guid DeclaredPurchaseId { get; set; }

    public PackageType PackageType { get; set; }

    public PackageStatus Status { get; set; }

    public decimal? WeightLb { get; set; }

    public decimal? WeightKg { get; set; }

    public int Pieces { get; set; }

    public bool IsRepacked { get; set; }

    public decimal? DeclaredValue { get; set; }

    public string Currency { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsFragile { get; set; }

    public string? Observations { get; set; }

    public DateTime? ReceivedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = [];

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomsCategory CustomsCategory { get; set; } = null!;

    public virtual DeclaredPurchase DeclaredPurchase { get; set; } = null!;

    public virtual Locker Locker { get; set; } = null!;

    public virtual ICollection<TrackingEvent> TrackingEvents { get; set; } = [];
}

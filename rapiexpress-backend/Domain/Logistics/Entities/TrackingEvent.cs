using Domain.Logistics.Enums;

namespace Domain.Logistics.Entities;

public class TrackingEvent
{
    public Guid Id { get; set; }

    public Guid PackageId { get; set; }

    public PackageStatus Status { get; set; }

    public string? Note { get; set; }

    public bool IsVisibleToCustomer { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Package Package { get; set; } = null!;
}

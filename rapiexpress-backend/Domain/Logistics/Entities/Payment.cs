using Domain.Logistics.Enums;

namespace Domain.Logistics.Entities;

public class Payment
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public Guid CustomerId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;
    public PaymentMethod Method { get; set; }

    public PaymentStatus Status { get; set; }

    public Guid ProofAttachmentId { get; set; }

    public string? Reference { get; set; }

    public string? RejectReason { get; set; }

    public Guid? ValidatedBy { get; set; }

    public DateTime? ValidatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Attachment ProofAttachment { get; set; } = null!;
}

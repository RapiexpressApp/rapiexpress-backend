using Domain.Logistics.Enums;

namespace Domain.Logistics.Entities;

public class Customer
{
    public Guid Id { get; set; }

    public Guid AppUserId { get; set; }

    public CustomerType CustomerType { get; set; }

    public string? DocumentId { get; set; }

    public string? BusinessName { get; set; }

    public string? Phone { get; set; }

    public string? Whatsapp { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<DeclaredPurchase> DeclaredPurchases { get; set; } = [];

    public virtual Locker? Locker { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = [];

    public virtual ICollection<Payment> Payments { get; set; } = [];
}

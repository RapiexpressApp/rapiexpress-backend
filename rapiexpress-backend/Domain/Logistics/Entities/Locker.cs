namespace Domain.Logistics.Entities;

public class Locker
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public string Code { get; set; } = null!;

    public string UsAddressLine { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? ZipCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Package> Packages { get; set; } = [];
}

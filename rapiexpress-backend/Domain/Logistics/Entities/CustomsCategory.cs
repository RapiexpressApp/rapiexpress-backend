namespace Domain.Logistics.Entities;

public class CustomsCategory
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? MaxDeclaredValue { get; set; }

    public decimal? MaxWeightKg { get; set; }

    public decimal? MaxWeightLb { get; set; }

    public string Currency { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<DeclaredPurchase> DeclaredPurchases { get; set; } = [];

    public virtual ICollection<Package> Packages { get; set; } = [];
}

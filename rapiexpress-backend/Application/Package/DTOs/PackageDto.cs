namespace Application.Package.DTOs;

public class PackageDto
{
    public string WarehouseNumber { get; set; } = null!;

    public string? ExternalTracking { get; set; }

    public decimal? WeightLb { get; set; }

    public int Pieces { get; set; }

    public bool IsRepacked { get; set; }

    public string? Description { get; set; }

    public decimal? DeclaredValue { get; set; }
}


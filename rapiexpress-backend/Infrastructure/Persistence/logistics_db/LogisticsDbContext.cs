using Domain.Logistics.Entities;
using Domain.Logistics.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.logistics_db;

public sealed class LogisticsDbContext(DbContextOptions<LogisticsDbContext> options) : DbContext(options)
{
    public DbSet<Attachment> Attachments => Set<Attachment>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<CustomsCategory> CustomsCategories => Set<CustomsCategory>();

    public DbSet<DeclaredPurchase> DeclaredPurchases => Set<DeclaredPurchase>();

    public DbSet<Locker> Lockers => Set<Locker>();

    public DbSet<Package> Packages => Set<Package>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<TrackingEvent> TrackingEvents => Set<TrackingEvent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<CustomerType>();
        modelBuilder.HasPostgresEnum<PackageType>();
        modelBuilder.HasPostgresEnum<PackageStatus>();
        modelBuilder.HasPostgresEnum<AttachmentType>();
        modelBuilder.HasPostgresEnum<PaymentMethod>();
        modelBuilder.HasPostgresEnum<PaymentStatus>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LogisticsDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Branch>()
            .HasKey(k => k.Id);

        modelBuilder.Entity<Customer>()
            .HasKey(k => k.Id);

        modelBuilder.Entity<Product>()
            .HasKey(k => k.Id);

        modelBuilder.Entity<Sale>()
            .HasKey(k => k.Id);

        modelBuilder.Entity<Sale>()
            .HasOne(s => s.Customer)
            .WithMany()
            .HasForeignKey(s => s.CustomerId);

        modelBuilder.Entity<Sale>()
            .HasOne(s => s.Branch)
            .WithMany()
            .HasForeignKey(s => s.BranchId);

        modelBuilder.Entity<Sale>()
            .HasMany(s => s.Items)
            .WithOne(si => si.Sale)
            .HasForeignKey(si => si.SaleId);

        modelBuilder.Entity<SaleItem>()
            .HasKey(k => k.Id);

        modelBuilder.Entity<SaleItem>()
            .HasOne(si => si.Sale)
            .WithMany(s => s.Items)
            .HasForeignKey(si => si.SaleId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SaleItem>()
            .HasOne(si => si.Product)
            .WithMany()
            .HasForeignKey(si => si.ProductId);

        SeedData.Seed(modelBuilder);
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
        )
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();

        return new DefaultContext(builder.Options);
    }
}

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var customers = new[]
        {
            new Customer { Id = Guid.NewGuid(), FirstName = "Marty", LastName = "McFly", Email = "marty.mcfly@example.com", Phone = "(11) 55555-1985", CreatedAt = DateTime.UtcNow },
            new Customer { Id = Guid.NewGuid(), FirstName = "Sarah", LastName = "Connor", Email = "sarah.connor@example.com", Phone = "(11) 55555-1984", CreatedAt = DateTime.UtcNow },
            new Customer { Id = Guid.NewGuid(), FirstName = "Ellen", LastName = "Ripley", Email = "ellen.ripley@example.com", Phone = "(11) 96555-1979", CreatedAt = DateTime.UtcNow },
            new Customer { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "(66) 43555-1970", CreatedAt = DateTime.UtcNow },
            new Customer { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", Phone = "(66) 43555-1971", CreatedAt = DateTime.UtcNow }
        };

        modelBuilder.Entity<Customer>().HasData(customers);

        var branches = new[]
        {
            new Branch { Id = Guid.NewGuid(), BranchName = "Cervejaria Alpha", Location = "São Paulo" },
            new Branch { Id = Guid.NewGuid(), BranchName = "Cervejaria Beta", Location = "Rio de Janeiro" },
            new Branch { Id = Guid.NewGuid(), BranchName = "Cervejaria Gamma", Location = "Belo Horizonte" }
        };

        modelBuilder.Entity<Branch>().HasData(branches);

        var products = new[]
        {
            new Product { Id = Guid.NewGuid(), ProductName = "Cerveja IPA", UnitPrice = 20.00M },
            new Product { Id = Guid.NewGuid(), ProductName = "Cerveja Stout", UnitPrice = 25.00M },
            new Product { Id = Guid.NewGuid(), ProductName = "Cerveja Lager", UnitPrice = 15.00M }
        };

        modelBuilder.Entity<Product>().HasData(products);

        var sales = new[]
        {
            new Sale { Id = Guid.NewGuid(), SaleNumber = "S0001", SaleDate = DateTime.UtcNow, CustomerId = customers[0].Id, BranchId = branches[0].Id, TotalSaleAmount = 80.00M, Status = SaleStatus.NotCancelled },
            new Sale { Id = Guid.NewGuid(), SaleNumber = "S0002", SaleDate = DateTime.UtcNow, CustomerId = customers[1].Id, BranchId = branches[1].Id, TotalSaleAmount = 240.00M, Status = SaleStatus.NotCancelled },
            new Sale { Id = Guid.NewGuid(), SaleNumber = "S0003", SaleDate = DateTime.UtcNow, CustomerId = customers[2].Id, BranchId = branches[2].Id, TotalSaleAmount = 200.00M, Status = SaleStatus.NotCancelled },
            new Sale { Id = Guid.NewGuid(), SaleNumber = "S0004", SaleDate = DateTime.UtcNow, CustomerId = customers[3].Id, BranchId = branches[0].Id, TotalSaleAmount = 100.00M, Status = SaleStatus.NotCancelled },
            new Sale { Id = Guid.NewGuid(), SaleNumber = "S0005", SaleDate = DateTime.UtcNow, CustomerId = customers[4].Id, BranchId = branches[1].Id, TotalSaleAmount = 300.00M, Status = SaleStatus.NotCancelled }
        };

        modelBuilder.Entity<Sale>().HasData(sales);

        var saleItems = new[]
        {
            new SaleItem { Id = Guid.NewGuid(), SaleId = sales[0].Id, ProductId = products[0].Id, Quantity = 4, Discount = 0.10M, TotalAmount = 4 * 20.00M * 0.90M },
            new SaleItem { Id = Guid.NewGuid(), SaleId = sales[1].Id, ProductId = products[1].Id, Quantity = 10, Discount = 0.20M, TotalAmount = 10 * 25.00M * 0.80M },
            new SaleItem { Id = Guid.NewGuid(), SaleId = sales[2].Id, ProductId = products[2].Id, Quantity = 13, Discount = 0.20M, TotalAmount = 13 * 15.00M * 0.80M },
            new SaleItem { Id = Guid.NewGuid(), SaleId = sales[3].Id, ProductId = products[0].Id, Quantity = 3, Discount = 0.00M, TotalAmount = 3 * 20.00M },
            new SaleItem { Id = Guid.NewGuid(), SaleId = sales[4].Id, ProductId = products[1].Id, Quantity = 15, Discount = 0.20M, TotalAmount = 15 * 25.00M * 0.80M }
    };

        modelBuilder.Entity<SaleItem>().HasData(saleItems);
    }

}
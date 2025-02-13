using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Mapping;
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
        //modelBuilder.Entity<Sale>(entity =>
        //{
        //    entity.HasKey(e => e.Id);

        //    entity.HasOne(e => e.Customer)
        //          .WithMany()
        //          .HasForeignKey("CustomerId")
        //          .OnDelete(DeleteBehavior.Cascade);

        //    entity.HasOne(e => e.Branch)
        //          .WithMany()
        //          .HasForeignKey("BranchId")
        //          .OnDelete(DeleteBehavior.Cascade);

        //    entity.Property(s => s.Status).IsRequired();
        //    entity.ToTable(s => s.HasCheckConstraint("CK_Sales_Status", "Status IN (1, 2)"));
        //});

        //modelBuilder.Entity<SaleItem>(entity =>
        //{
        //    entity.HasKey(e => e.Id);

        //    entity.HasOne(e => e.Sale)
        //          .WithMany()
        //          .HasForeignKey("SaleId")
        //          .OnDelete(DeleteBehavior.Cascade);

        //    entity.HasOne(e => e.Product)
        //          .WithMany()
        //          .HasForeignKey("ProductId")
        //          .OnDelete(DeleteBehavior.Cascade);

        //    entity.Property(e => e.Quantity)
        //          .IsRequired()
        //          .HasColumnType("integer");

        //    entity.Property(e => e.Discount)
        //          .IsRequired()
        //          .HasColumnType("numeric");

        //    entity.Property(e => e.TotalAmount)
        //          .IsRequired()
        //          .HasColumnType("numeric");
        //});
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        //modelBuilder.ApplyConfiguration(new BranchConfiguration());
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        //modelBuilder.ApplyConfiguration(new SaleConfiguration());
        //modelBuilder.ApplyConfiguration(new SaleItemConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
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
        );

        return new DefaultContext(builder.Options);
    }
}
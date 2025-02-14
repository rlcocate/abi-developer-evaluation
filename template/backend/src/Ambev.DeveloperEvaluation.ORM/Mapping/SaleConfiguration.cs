using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.SaleNumber).IsRequired().HasMaxLength(50);
            builder.Property(s => s.SaleDate).IsRequired().HasColumnType("date");

            builder.HasOne(s => s.Customer)
                   .WithMany()
                   .HasForeignKey("CustomerId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Branch)
                   .WithMany()
                   .HasForeignKey("BranchId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.TotalSaleAmount).IsRequired().HasColumnType("decimal");

            builder.Property(s => s.Status).HasConversion<string>().IsRequired().HasMaxLength(20);
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("serial");

            builder.Property(s => s.SaleNumber).IsRequired().HasMaxLength(255);
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

            builder.Property(s => s.Status).IsRequired();
            builder.ToTable(s => s.HasCheckConstraint("CK_Sales_Status", "Status IN (1, 2)"));
        }
    }
}

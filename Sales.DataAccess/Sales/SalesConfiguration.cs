using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Sales
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
                .Property(s => s.Customer)
                .IsRequired();

            builder
                .Property(s => s.Employee)
                .IsRequired();

            builder
                .Property(s => s.Product)
                .IsRequired();

            builder
                .Property(s => s.UnitPrice)
                .IsRequired();

            builder
                .Property(s => s.TotalPrice)
                .IsRequired();

            builder
                .Property(s => s.Date)
                .IsRequired();

            builder
                .Property(s => s.Quantity)
                .IsRequired();

            builder
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.Customer.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(s => s.Employee)
                .WithMany(e => e.Sales)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(s => s.Product)
                .WithMany(e => e.Sales)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

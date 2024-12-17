using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncRazorForms.Models;

namespace SyncRazorForms.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
{
    public void Configure(EntityTypeBuilder<OrderModel> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        builder.HasMany(o => o.Products)
            .WithMany(p => p.Orders);
    }
}
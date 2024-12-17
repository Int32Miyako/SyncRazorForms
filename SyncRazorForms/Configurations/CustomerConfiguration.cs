using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncRazorForms.Models;

namespace SyncRazorForms.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<CustomerModel>
{
    public void Configure(EntityTypeBuilder<CustomerModel> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
    }
}
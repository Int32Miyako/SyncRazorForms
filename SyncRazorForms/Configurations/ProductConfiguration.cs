using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncRazorForms.Models;

namespace SyncRazorForms.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.Orders)
            .WithMany(o => o.Products);
    }
}
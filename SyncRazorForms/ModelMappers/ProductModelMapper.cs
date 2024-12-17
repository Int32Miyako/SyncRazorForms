using SyncRazorForms.Data.EF;
using SyncRazorForms.Models;

namespace SyncRazorForms.ModelMappers;

public class ProductModelMapper : IProductModelMapper
{
    public ProductModel MapToModel(Product entity)
    {
        return new ProductModel();
    }
    
    
    public Product MapFromModel(ProductModel model)
    {
        return new Product();
    }
}
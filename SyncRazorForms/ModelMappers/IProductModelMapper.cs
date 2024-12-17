using SyncRazorForms.Models;
using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Data.EF;

public interface IProductModelMapper
{
    public Product MapFromModel(ProductModel model);

    public ProductModel MapToModel(Product entity);
}
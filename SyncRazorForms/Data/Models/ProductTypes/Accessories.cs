using SyncRazorForms.Data.Models.ProductTypes;

namespace SyncRazorForms.Models.ProductTypes;

public class Accessories : ProductModel
{
    public new ProductTypeModel ProductTypeModel { get; set; }

    public string? Material { get; set; }
}
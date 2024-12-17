using SyncRazorForms.Data.Models.ProductTypes;

namespace SyncRazorForms.Models.ProductTypes;

public class AccessoriesModel : ProductModel
{
    public override ProductType ProductType { get; protected set; } = ProductType.Accessories;
    public string? Material { get; set; }
}
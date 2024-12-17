using SyncRazorForms.Data.Models.ProductTypes;

namespace SyncRazorForms.Models.ProductTypes;

public class FoodModel : ProductModel
{
    public override ProductType ProductType { get; protected set; } = ProductType.Food;

    public DateTime ExpirationDate { get; set; }
}

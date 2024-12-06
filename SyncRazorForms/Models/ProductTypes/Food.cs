namespace SyncRazorForms.Models.ProductTypes;

public class Food : Product
{
    public new ProductType ProductType { get; } = ProductType.Food;
}
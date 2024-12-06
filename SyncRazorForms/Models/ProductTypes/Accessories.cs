namespace SyncRazorForms.Models.ProductTypes;

public class Accessories : Product
{
    public new ProductType ProductType { get; } = ProductType.Accessories;
}
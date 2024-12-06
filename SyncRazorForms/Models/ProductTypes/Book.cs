namespace SyncRazorForms.Models.ProductTypes;

public class Book : Product
{
    public new ProductType ProductType { get; } = ProductType.Book;
}
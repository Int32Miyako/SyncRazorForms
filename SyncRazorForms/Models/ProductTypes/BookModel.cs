using SyncRazorForms.Data.Models.ProductTypes;

namespace SyncRazorForms.Models.ProductTypes;

public class BookModel : ProductModel
{
    public override ProductType ProductType { get; protected set; } = ProductType.Book;
    public string Author { get; set; }
}
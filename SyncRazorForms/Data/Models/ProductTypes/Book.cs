using SyncRazorForms.Data.Models.ProductTypes;

namespace SyncRazorForms.Models.ProductTypes;

public class Book : ProductModel
{

    public new ProductTypeModel ProductTypeModel { get; set; }

    public string Author { get; set; }
}
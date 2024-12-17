using SyncRazorForms.Data.Models.ProductTypes;

namespace SyncRazorForms.Models.ProductTypes;

public class Food : ProductModel
{
    public new ProductTypeModel ProductTypeModel { get; set; }
    
    public DateTime ExpirationDate { get; set; }
}
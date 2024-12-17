using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Models;

public class IndexModel
{
    public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
    
    
}


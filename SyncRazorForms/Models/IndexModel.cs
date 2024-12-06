using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Models;

public class IndexModel
{
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Order> Orders { get; set; } = new List<Order>();
    public List<Customer> Customers { get; set; } = new List<Customer>();
    
    
}


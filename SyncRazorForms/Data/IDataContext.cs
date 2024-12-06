using SyncRazorForms.Models;

namespace SyncRazorForms.Data
{
    public interface IDataContext
    {
        public Product? SelectProduct(int id);
        public IList<Product?> SelectProducts();
        public int InsertProduct(Product product);
        
        public int UpdateProduct(Product newProduct);
        public int DeleteProduct(int id);
    

        public Customer? SelectCustomer(int id);
        public IList<Customer?> SelectCustomers();
        public int InsertCustomer(Customer customer);
        
        public int UpdateCustomer(Customer customer);
        public int DeleteCustomer(int id);

    
        public Order? SelectOrder(int id);
        public IList<Order?> SelectOrders();
        public int InsertOrder(Order order);
        
        public int UpdateOrder(Order order);
        public int DeleteOrder(int id);
    }
}
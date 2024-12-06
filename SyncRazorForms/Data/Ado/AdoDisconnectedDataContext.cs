using SyncRazorForms.Models;
using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Data.Ado;

public class AdoDisconnectedDataContext : IDataContext
{
    public Product? SelectProduct(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Product?> SelectProducts()
    {
        throw new NotImplementedException();
    }

    public int InsertProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public int UpdateProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public int UpdateProduct(int id, IDictionary<string, object> args)
    {
        throw new NotImplementedException();
    }

    public int DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Customer? SelectCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Customer?> SelectCustomers()
    {
        throw new NotImplementedException();
    }
    

    public int InsertCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public int UpdateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }


    public int InsertCustomer(Product product)
    {
        throw new NotImplementedException();
    }

    public int UpdateCustomer(int id, IDictionary<string, object> args)
    {
        throw new NotImplementedException();
    }

    public int DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public Order? SelectOrder(int id)
    {
        throw new NotImplementedException();
    }
    

    public IList<Order?> SelectOrders()
    {
        throw new NotImplementedException();
    }

    public int InsertOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public int UpdateOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public int InsertOrder(Product product)
    {
        throw new NotImplementedException();
    }

    public int UpdateOrder(int id, IDictionary<string, object> args)
    {
        throw new NotImplementedException();
    }

    public int DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }
}
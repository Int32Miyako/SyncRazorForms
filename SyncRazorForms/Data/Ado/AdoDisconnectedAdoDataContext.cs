using SyncRazorForms.Models;
using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Data.Ado;

public class AdoDisconnectedAdoDataContext : IAdoDataContext
{
    public ProductModel? SelectProduct(int id)
    {
        throw new NotImplementedException();
    }

    public IList<ProductModel?> SelectProducts()
    {
        throw new NotImplementedException();
    }

    public int InsertProduct(ProductModel productModel)
    {
        throw new NotImplementedException();
    }

    public int UpdateProduct(ProductModel newProductModel)
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

    public CustomerModel? SelectCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public IList<CustomerModel?> SelectCustomers()
    {
        throw new NotImplementedException();
    }
    

    public int InsertCustomer(CustomerModel customerModel)
    {
        throw new NotImplementedException();
    }

    public int UpdateCustomer(CustomerModel customerModel)
    {
        throw new NotImplementedException();
    }


    public int InsertCustomer(ProductModel productModel)
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

    public OrderModel? SelectOrder(int id)
    {
        throw new NotImplementedException();
    }
    

    public IList<OrderModel?> SelectOrders()
    {
        throw new NotImplementedException();
    }

    public int InsertOrder(OrderModel orderModel)
    {
        throw new NotImplementedException();
    }

    public int UpdateOrder(OrderModel newOrderModel)
    {
        throw new NotImplementedException();
    }

    public int InsertOrder(ProductModel productModel)
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
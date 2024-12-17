using Microsoft.EntityFrameworkCore;
using SyncRazorForms.Models;

namespace SyncRazorForms.Data.EF;

public interface IEfDataContext
{
    public DbSet<CustomerModel> Customers { get; init; }
    public DbSet<OrderModel> Orders { get; init; }
    
    public ProductModel? SelectProduct(int id);
    public int InsertProduct(ProductModel productModel);
    public int UpdateProduct(ProductModel newProductModel);
    public int DeleteProduct(int id);
    

    public CustomerModel? SelectCustomer(int id);
    public int InsertCustomer(CustomerModel customerModel);
    public int UpdateCustomer(CustomerModel customerModel);
    public int DeleteCustomer(int id);

    
    public OrderModel? SelectOrder(int id);
    public int InsertOrder(OrderModel orderModel);
    public int UpdateOrder(OrderModel newOrderModel);
    public int DeleteOrder(int id);
}
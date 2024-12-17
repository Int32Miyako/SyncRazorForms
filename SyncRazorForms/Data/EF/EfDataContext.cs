using Microsoft.EntityFrameworkCore;
using SyncRazorForms.Configurations;
using SyncRazorForms.Data.Models.ProductTypes;
using SyncRazorForms.Models;
using SyncRazorForms.Models.ProductTypes;
using ProductType = SyncRazorForms.Data.Models.ProductTypes.ProductType;

namespace SyncRazorForms.Data.EF;

public sealed class EfDataContext : DbContext, IEfDataContext
{
    public DbSet<CustomerModel> Customers { get; init; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<OrderModel> Orders { get; init; }
    
    public DbSet<BookModel> Books { get; init; }
    public DbSet<FoodModel> Foods { get; init; }
    public DbSet<AccessoriesModel> Accessories { get; init; }

    
    private readonly IConfiguration _configuration;
    
public EfDataContext(IConfiguration configuration, DbContextOptions<EfDataContext> options)
    : base(options)
{
    _configuration = configuration;

}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<ProductModel>()
            .HasDiscriminator<ProductType>("ProductType")
            .HasValue<ProductModel>(ProductType.Default)
            .HasValue<BookModel>(ProductType.Book)
            .HasValue<FoodModel>(ProductType.Food)
            .HasValue<AccessoriesModel>(ProductType.Accessories);


        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        
        base.OnModelCreating(modelBuilder); // хз как и почему так передаём
        // странный и безполезный вызов метода
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.LogTo(Console.WriteLine);
    //    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("RenderDB"));
    //}
   
   /// <summary>
   /// Customers
   /// </summary>
   /// <returns></returns>
   
    public CustomerModel? SelectCustomer(int id)
    {
        return Customers.FirstOrDefault(customer => customer.Id == id);
    }
    
    public int InsertCustomer(CustomerModel customerModel)
    {
        Customers.Add(customerModel);
        SaveChanges();
        return Customers.Last().Id;
    }

    public int UpdateCustomer(CustomerModel newCustomerModel)
    {
        var existingCustomer = Customers.Find(newCustomerModel.Id);
        if (existingCustomer == null) return 0;
        
        Entry(existingCustomer).CurrentValues.SetValues(newCustomerModel);

        SaveChanges();
        return newCustomerModel.Id;
    }


    public int DeleteCustomer(int id)
    {
        var existingCustomer = Customers.Find(id);
        if (existingCustomer == null) return 0;

        Customers.Remove(existingCustomer);

        SaveChanges();
        return existingCustomer.Id;
    }


    /// <summary>
    /// Orders
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public OrderModel? SelectOrder(int id)
    {
        return Orders.Find(id);
    }

    public int InsertOrder(OrderModel orderModel)
    {
        Orders.Add(orderModel);
        
        return orderModel.Id;
    }

    public int UpdateOrder(OrderModel newOrderModel)
    {
        var existingOrder = Orders.Find(newOrderModel.Id);
        if (existingOrder == null) return 0;
        
        Entry(existingOrder).CurrentValues.SetValues(newOrderModel);

        SaveChanges();

        return newOrderModel.Id;
    }

    public int DeleteOrder(int id)
    {
        var existingOrder = Orders.Find(id);
        if (existingOrder == null) return 0;
        
        Orders.Remove(existingOrder);
        
        SaveChanges();
        return existingOrder.Id;
    }
    
    
    /// <summary>
    /// Products
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ProductModel? SelectProduct(int id)
    {
        return Products.Find(id);
    }

    public int InsertProduct(ProductModel productModel)
    {
        Products.Add(productModel);
        SaveChanges();
        return productModel.Id;
    }
    
    public int UpdateProduct(ProductModel newProductModel)
    {
        var existingProduct = Products.Find(newProductModel.Id);
        if (existingProduct is null) return 0;
        
        Entry(existingProduct).CurrentValues.SetValues(newProductModel);

        SaveChanges();
        return newProductModel.Id;
    }

    public int DeleteProduct(int id)
    {
        var existingProduct = Products.Find(id);
        if (existingProduct is null) return 0;

        Products.Remove(existingProduct);

        SaveChanges();
        return existingProduct.Id;
    }
}
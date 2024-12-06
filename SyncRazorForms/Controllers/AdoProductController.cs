using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using SyncRazorForms.Data;
using SyncRazorForms.Data.Ado;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers;

[Route("[controller]")]
public class AdoProductController : ControllerBase
{
    private readonly IDataContext _dataContext;

    public AdoProductController()
    {
        var mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder
        {
            Server = "127.127.126.26",
            Port = 3306,
            Database = "ProductShop_DB",
            UserID = "root",
            Password = ""
        };

        _dataContext = new AdoConnectedDataContext(mySqlConnectionStringBuilder.ConnectionString);
    }
    

    [HttpGet("products")]
    public IList<Product?> GetProducts()
    {
        return _dataContext.SelectProducts();
    }
    
    [HttpGet("get-product/{id}")]
    public Product? GetProduct([FromRoute]int id)
    {
        return _dataContext.SelectProduct(id);
    }

    [HttpPost("products")]
    public int InsertProducts([FromBody] Product product)
    {
        return _dataContext.InsertProduct(product);
    }

    [HttpPut("products")]
    public int UpdateProducts([FromBody] Product newProduct)
    {
        return _dataContext.UpdateProduct(newProduct);
    }
    
    
    
    
    
    
    [HttpPost("create-product")] 
    public int CreateProduct()
    {
        var newProduct = new Product
        {
            Id = CreateId(),
            Name = "",
            Description = "",
            Cost = 0, 
            Amount = 0
        };

        _dataContext.InsertProduct(newProduct);

        return newProduct.Id;
    }
    
    
    [HttpPut("update-product")]
    public Product UpdateProduct([FromBody] Product productFromBody)
    {
        _dataContext.UpdateProduct(productFromBody);
    
        return productFromBody;
    }

    

    [HttpDelete("delete-product/{id}")]
    public void DeleteProduct([FromRoute] int id)
    {
        _dataContext.DeleteProduct(id);
    }


    private static int CreateId()
    {
        while (true)
        {
            var randomGenerator = new Random();
            var id = randomGenerator.Next(0, 1000000);

            return id;
        }
    }
}
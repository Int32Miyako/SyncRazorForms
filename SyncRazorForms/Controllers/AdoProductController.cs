using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Npgsql;
using SyncRazorForms.Data;
using SyncRazorForms.Data.Ado;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers;

[Route("[controller]/product")]
public class AdoProductController : ControllerBase
{
    private readonly IDataContext _dataContext;

    public AdoProductController()
    {
        var npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = "dpg-cta4pp56l47c73bhve1g-a.frankfurt-postgres.render.com",
            Port = 5432, 
            Database = "globaldb_4wbf",
            Username = "globaldb_4wbf_user",
            Password = "2ceO0bvsTcrY4oTGslx0WtOocZTB4pv7"
        };

        _dataContext = new AdoConnectedDataContext(npgsqlConnectionStringBuilder.ConnectionString);
    }
    

    [HttpGet] // все продукты
    public IList<Product?> GetProducts()
    {
        return _dataContext.SelectProducts();
    }
    
    [HttpGet("{id}")]
    public Product? GetProduct([FromRoute]int id)
    {
        return _dataContext.SelectProduct(id);
    }

   
    
    
    [HttpPost] 
    public int CreateProduct()
    {
        var id = _dataContext.InsertProduct(new Product
        {
            Name = "",
            Description = "",
            Cost = 0,
            Amount = 0
        });

        return id;
    }
    
    
    [HttpPut]
    public Product UpdateProduct([FromBody] Product productFromBody)
    {
        _dataContext.UpdateProduct(productFromBody);
    
        return productFromBody;
    }

    

    [HttpDelete("{id}")]
    public void DeleteProduct([FromRoute] int id)
    {
        _dataContext.DeleteProduct(id);
    }


    
}
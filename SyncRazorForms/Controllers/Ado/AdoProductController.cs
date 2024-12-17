using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SyncRazorForms.Data;
using SyncRazorForms.Data.Ado;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers.Ado;

[Route("[controller]/product")]
public class AdoProductController : ControllerBase
{
    private readonly IAdoDataContext _adoDataContext;

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

        _adoDataContext = new AdoConnectedAdoDataContext(npgsqlConnectionStringBuilder.ConnectionString);
    }
    

    [HttpGet] // все продукты
    public IList<ProductModel?> GetProducts()
    {
        return _adoDataContext.SelectProducts();
    }
    
    [HttpGet("{id}")]
    public ProductModel? GetProduct([FromRoute]int id)
    {
        return _adoDataContext.SelectProduct(id);
    }

   
    
    
    [HttpPost] 
    public int CreateProduct()
    {
        var id = _adoDataContext.InsertProduct(new ProductModel
        {
            Name = "",
            Description = "",
            Price = 0,
            Amount = 0
        });

        return id;
    }
    
    
    [HttpPut]
    public ProductModel UpdateProduct([FromBody] ProductModel productModelFromBody)
    {
        _adoDataContext.UpdateProduct(productModelFromBody);
    
        return productModelFromBody;
    }

    

    [HttpDelete("{id}")]
    public void DeleteProduct([FromRoute] int id)
    {
        _adoDataContext.DeleteProduct(id);
    }


    
}
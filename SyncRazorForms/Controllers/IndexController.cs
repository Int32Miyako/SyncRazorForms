using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using SyncRazorForms.Data.Ado;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers;

public class IndexController : ControllerBase
{
    private readonly AdoConnectedDataContext _adoConnectedDataContext;

    public IndexController()
    {
        var mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder
        {
            Server = "127.127.126.26",
            Port = 3306,
            Database = "ProductShop_DB",
            UserID = "root",
            Password = ""
        };

        _adoConnectedDataContext = new AdoConnectedDataContext(mySqlConnectionStringBuilder.ConnectionString);
    }

    [HttpGet("products")]
    public IList<Product?> GetProducts()
    {
        return _adoConnectedDataContext.SelectProducts();
    }

    [HttpPost("products")]
    public int InsertProducts([FromBody] Product product)
    {
        return _adoConnectedDataContext.InsertProduct(product);
    }

    [HttpPut("products")]
    public int UpdateProducts([FromBody] Product newProduct)
    {
        return _adoConnectedDataContext.UpdateProduct(newProduct);
    }
}
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

    public AdoProductController(IAdoDataContext adoDataContext)
    {
        _adoDataContext = adoDataContext;
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
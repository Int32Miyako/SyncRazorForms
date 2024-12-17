using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncRazorForms.Data.EF;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers.EntityFramework.Api;

[Route("api/EfProductApi")]
public class EfProductApiController : ControllerBase
{
 
    private readonly EfDataContext _dataContext;
    
    public EfProductApiController(EfDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    [HttpGet]
    public List<ProductModel> GetProducts()
    {
        return _dataContext.Products
            .AsNoTracking()
            .ToList();                                                                                                                
    }
    
    [HttpGet("{id:int}")]
    public ProductModel? GetProduct([FromRoute]int id)
    {
        return _dataContext.SelectProduct(id);
    }
    
    [HttpPost] 
    public int CreateProduct()
    {
            var product = new ProductModel
            {
                Name = "",
                Description = "",
                Price = 0,
                Amount = 0
            };

            return _dataContext.InsertProduct(product);
    }
    
    [HttpPut]
    public ProductModel UpdateProduct([FromBody] ProductModel productModelFromBody)
    {
        _dataContext.UpdateProduct(productModelFromBody);
    
        return productModelFromBody;
    }

    [HttpDelete("{id:int}")]
    public void DeleteProduct([FromRoute] int id)
    {
        _dataContext.DeleteProduct(id);
    }
    
    
   
}
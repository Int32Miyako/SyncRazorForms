using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncRazorForms.Data.EF;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers.EntityFramework;

[Route("[controller]/product")]
public class EfProductController : Controller
{
 
    private readonly EfDataContext _dataContext;
    
    public EfProductController(EfDataContext dataContext)
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
    public ObjectResult CreateProduct()
    {
        try
        {
            var product = new ProductModel
            {
                Name = "",
                Description = "",
                Price = 0,
                Amount = 0
            };

            return Ok(_dataContext.InsertProduct(product));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return StatusCode(500, "Произошла ошибка на сервере");
        }
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
    
    
    [HttpGet("view")]
    public IActionResult Index()
    {
        var products = _dataContext.Products
            .AsNoTracking()
            .ToList();
        
        return View(products); // Передаем список продуктов в представление
    }
    
}
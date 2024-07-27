using Microsoft.AspNetCore.Mvc;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers;

[Route("product")]
public class ProductController : ControllerBase // урезанный вариант
// контроллера необходимый для работы именно с api 
{
    private static readonly List<ProductModel> _products = new()
    {
        new ProductModel()
        {
            Name = "nameProduct",
        }
    };
    
    
    [HttpGet("{id}")]
    public ProductModel? GetProduct([FromRoute]int id)
    {
        var products = _products;
        
        for (var i = 0; i < products?.Count; i++)
        {
            if(products[i].Id == id)
                return products[i];
        }
        
        return null;
    }
    
    
}
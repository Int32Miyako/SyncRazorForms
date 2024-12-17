using Microsoft.AspNetCore.Mvc;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers.Temp;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    public static readonly IndexModel? IndexModel = new IndexModel();
    
    
    [HttpGet("get-products")]
    public List<ProductModel>? GetProducts()
    {
        List<ProductModel>? products = IndexModel?.Products;

        return products;
    }
    
    [HttpGet("get-product/{id}")] 
    public ProductModel? GetProduct([FromRoute]int id)
    {
        var products = IndexModel!.Products;

        return products!.FirstOrDefault(product => product.Id == id);
    }
    
    
    [HttpPost("create-product")] 
    public int CreateProduct()
    {
        var newProduct = new ProductModel
        {
            Id = CreateId(),
            Name = "",
            Description = "",
            Price = 0, 
            Amount = 0
        };

        IndexModel!.Products!.Add(newProduct);

        return Convert.ToInt32(newProduct.Id);
    }
    
    
    [HttpPut("update-product")]
    public ProductModel? UpdateProduct([FromBody] ProductModel productModel)
    {
        if (IndexModel != null)
            for (var i = 0; i < IndexModel.Products!.Count; i++)
            {
                if (IndexModel.Products[i].Id == productModel.Id)
                {
                    IndexModel.Products[i] = productModel;
                    return IndexModel.Products[i];
                }
            }

        return null;
    }

    

    [HttpDelete("delete-product/{id}")]
    public void DeleteProduct([FromRoute] int id)
    {
        if (IndexModel != null) IndexModel.Products = IndexModel.Products!.Where(p => p.Id != id).ToList();
    }


    private static int CreateId()
    {
        while (true)
        {
            var randomGenerator = new Random();

            var id = randomGenerator.Next(0, 1000000);

            if (IndexModel is { Products: not null } && IndexModel.Products.Any(t => t.Id == id)) continue;
            return id;
        }
    }
}
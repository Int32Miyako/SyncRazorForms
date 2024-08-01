﻿using Microsoft.AspNetCore.Mvc;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    public static readonly IndexModel IndexModel = new();
    
    [HttpGet("get-product/{id}")]
    public ProductModel? GetProduct([FromRoute]int id)
    {
        var products = IndexModel.Products;

        return products.FirstOrDefault(t => t.Id == id);
    }
    
    [HttpPost("create-product")] 
    public int CreateProduct()
    {
        var newProduct = new ProductModel
        {
            Id = CreateId(),
            Name = "",
            Description = "",
            Cost = 0, 
            Amount = 0
        };

        IndexModel.Products.Add(newProduct);

        return newProduct.Id;
    }
    
    
    [HttpPut("update-product")]
    public ProductModel? UpdateProduct([FromBody] ProductModel product)
    {
        for (var i = 0; i < IndexModel.Products.Count; i++)
        {
            if (IndexModel.Products[i].Id == product.Id)
            {
                IndexModel.Products[i] = product;
                return IndexModel.Products[i];
            }
        }

        return null;
    }

    

    [HttpDelete("delete-product/{id}")]
    public void DeleteProduct([FromRoute] int id)
    {
        IndexModel.Products = IndexModel.Products.Where(p => p.Id != id).ToList();
    }


    private static int CreateId()
    {
        while (true)
        {
            var randomGenerator = new Random();

            var id = randomGenerator.Next(0, 1000000);

            if (IndexModel.Products.Any(t => t.Id == id)) continue;
            return id;
        }
    }
}
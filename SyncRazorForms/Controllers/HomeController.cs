using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SyncRazorForms.Models;

namespace SyncRazorForms.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private static readonly IndexModel IndexModel = new();

    [HttpPost("create-product")] //сменили адрес
    public IActionResult CreateProduct([FromForm] ProductModel newProduct)
    {
        newProduct.Id = GetId();
        
        IndexModel.Products!.Add(newProduct);

        SortProductsById();

        return RedirectToAction("Index"); //код 302
    }

    private void SortProductsById()
    {
        IndexModel.Products = IndexModel.Products?.OrderBy(x => x.Id).ToList();
    }

    [HttpPost("update-product")]
    public IActionResult UpdateProduct([FromForm] ProductModel product)
    {
        for (var i = 0; i < IndexModel.Products?.Count; i++)
        {
            if (IndexModel.Products[i].Id == product.Id)
            {
                IndexModel.Products[i] = product;

                SortProductsById();

                break;
            }
        }

        return RedirectToAction("Index");
    }


    [HttpGet("begin-update")]
    public IActionResult BeginUpdate(int id)
    {
        var product = IndexModel.Products!.FirstOrDefault(p => p.Id == id);

        if (product != null)
        {
            TempData["productToUpdate"] = System.Text.Json.JsonSerializer.Serialize(product);
        }

        return RedirectToAction("Index");
    }


    [HttpPost("delete-product")]
    public IActionResult DeleteProduct([FromForm] int id)
    {
        IndexModel.Products = IndexModel.Products!.Where(p => p.Id != id).ToList();

        return RedirectToAction("Index");
    }

    private int GetId()
    {
        var randomGenerator = new Random();
        
        var id = randomGenerator.Next(0, 1000000);
        
        for (var i = 0; i < IndexModel.Products?.Count; i++)
        {
            if (IndexModel.Products[i].Id == id)
            {
                return GetId();
            }
        }

        return id;
    } 
    public IActionResult Index()
    {
        return View(IndexModel);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
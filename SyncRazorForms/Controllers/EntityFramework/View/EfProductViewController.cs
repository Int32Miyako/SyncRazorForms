using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncRazorForms.Data.EF;

namespace SyncRazorForms.Controllers.EntityFramework.View;

[Route("[controller]")]
public class EfProductViewController : Controller
{
    private readonly EfDataContext _dataContext;

    public EfProductViewController(EfDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> Products()
    {
        
        var products = await _dataContext.Products
            .AsNoTracking()
            .ToListAsync();
        
        return View(products);
    }
}
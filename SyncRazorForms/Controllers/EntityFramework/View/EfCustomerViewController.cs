using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncRazorForms.Data.EF;

namespace SyncRazorForms.Controllers.EntityFramework.View;

[Route("[controller]")]
public class EfCustomerViewController : Controller
{
    private readonly EfDataContext _dataContext;

    public EfCustomerViewController(EfDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> Customers()
    {
        var customers = await _dataContext.Customers
            .AsNoTracking()
            .ToListAsync();
        
        return View(customers);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncRazorForms.Data.EF;

namespace SyncRazorForms.Controllers.EntityFramework.View;

[Route("[controller]")]
public class EfOrderViewController : Controller
{
    private readonly EfDataContext _dataContext;

    public EfOrderViewController(EfDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        var orders = await _dataContext.Orders
            .Include(o => o.Products) // Подгружаем связанные продукты
            .AsNoTracking()
            .ToListAsync();

        return View(orders);
    }
}
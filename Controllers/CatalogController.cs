using CatalogViewer.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogViewer.Controllers;

public class CatalogController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var catalogs = _dbContext.Catalogs
            .Include(c => c.Children)
            .Where(c => c.ParentId == null)
            .ToList();

        return View(catalogs);
    }

    public ActionResult Details(int id)
    {
        var folder = _dbContext.Catalogs
            .Include(c => c.Children)
            .FirstOrDefault(c => c.Id == id);

        if (folder == null)
        {
            return NotFound();
        }

        return View(folder);
    }

}
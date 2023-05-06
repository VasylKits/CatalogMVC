using CatalogViewer.Services.Intefraces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogViewer.Controllers;

public class ImportController : Controller
{
    private readonly IImportService _importService;

    public ImportController(IImportService importService)
    {
        _importService = importService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Export()
    {
        await _importService.ExportInJson();

        return Content("Catalog structure successfully exported to \"catalogs.json\" file!");
    }
}
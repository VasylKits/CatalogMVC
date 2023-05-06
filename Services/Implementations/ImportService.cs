using CatalogViewer.DB;
using CatalogViewer.Models;
using CatalogViewer.Services.Intefraces;
using Newtonsoft.Json;

namespace CatalogViewer.Services.Implementations;

public class ImportService : IImportService
{
    private readonly ApplicationDbContext _dbContext;

    public ImportService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> ExportInJson()
    {
        List<Catalog> catalogs = _dbContext.Catalogs.ToList();

        string json = JsonConvert.SerializeObject(catalogs, Formatting.Indented);

        File.WriteAllText("catalogs.json", json);

        return "Структуру каталогів успішно експортовано у файл JSON!";
    }
}
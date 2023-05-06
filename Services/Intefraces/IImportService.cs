namespace CatalogViewer.Services.Intefraces;

public interface IImportService
{
    Task<string> ExportInJson();
}
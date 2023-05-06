using CatalogViewer.DB;
using CatalogViewer.Models;

namespace CatalogViewer.Extensions;

public static class CatalogInitializer
{
    public static IHost Seed(this IHost webHost)
    {
        using var scope = webHost.Services.CreateScope();
        {
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                context.Database.EnsureCreated();

                if (!context.Catalogs.Any())
                {
                    var creatingDigitalImagesFolder = new Catalog { Name = "Creating Digital Images" };
                    var resourcesFolder = new Catalog { Name = "Resources", Parent = creatingDigitalImagesFolder };
                    var evidenceFolder = new Catalog { Name = "Evidence", Parent = creatingDigitalImagesFolder };
                    var graphicProductsFolder = new Catalog { Name = "Graphic Products", Parent = creatingDigitalImagesFolder };
                    var primarySourcesFolder = new Catalog { Name = "Primary Sources", Parent = resourcesFolder };
                    var secondarySourcesFolder = new Catalog { Name = "Secondary Sources", Parent = resourcesFolder };
                    var processFolder = new Catalog { Name = "Process", Parent = graphicProductsFolder };
                    var finalProductFolder = new Catalog { Name = "Final Product", Parent = graphicProductsFolder };

                    context.Catalogs.AddRange(new[]
                    {
                        creatingDigitalImagesFolder,
                        resourcesFolder,
                        evidenceFolder,
                        graphicProductsFolder,
                        primarySourcesFolder,
                        secondarySourcesFolder,
                        processFolder,
                        finalProductFolder
                    });

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        return webHost;
    }
}
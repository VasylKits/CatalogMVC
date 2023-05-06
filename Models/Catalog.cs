using Newtonsoft.Json;

namespace CatalogViewer.Models;

public class Catalog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }

    [JsonIgnore]
    public virtual Catalog? Parent { get; set; }
    public virtual ICollection<Catalog>? Children { get; set; }
}

namespace SB.Models.Base;

/// <summary>
/// Colección paginada con metadatos. Calcula HasItems automáticamente.
/// </summary>
public class DataCollection<T>
{
    public bool HasItems => Items != null && Items.Any();
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int Total { get; set; }
    public int Page { get; set; }
    public int Pages { get; set; }
}

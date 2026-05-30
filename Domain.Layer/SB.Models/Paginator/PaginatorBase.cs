namespace SB.Models.Paginator;

/// <summary>
/// Parámetros base de paginación. Todos los paginators concretos heredan de aquí.
/// </summary>
public abstract class PaginatorBase
{
    private int _page = 1;
    private int _take = 20;

    /// <summary>Página solicitada (>= 1).</summary>
    public int Page
    {
        get => _page;
        set => _page = value < 1 ? 1 : value;
    }

    /// <summary>Tamaño de página (1..100).</summary>
    public int Take
    {
        get => _take;
        set => _take = value < 1 ? 1 : (value > 100 ? 100 : value);
    }
}

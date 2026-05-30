namespace SB.Models.Paginator;

/// <summary>
/// Filtros de paginación para empleados. Incluye búsqueda por nombre,
/// filtro por departamento y por estado.
/// </summary>
public class PaginatorEmpleadoDto : PaginatorBase
{
    public int? Codigo { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public int? DepartmentoId { get; set; }
    public int? TipoEmpleado { get; set; }
    public bool? Activo { get; set; }
}

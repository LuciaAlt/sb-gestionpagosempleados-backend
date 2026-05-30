namespace SB.Models.Paginator;

public class PaginatorAuditoriaDto : PaginatorBase
{
    public string? Accion { get; set; }
    public string? Entidad { get; set; }
    public string? Usuario { get; set; }
    public DateTimeOffset? Desde { get; set; }
    public DateTimeOffset? Hasta { get; set; }
}

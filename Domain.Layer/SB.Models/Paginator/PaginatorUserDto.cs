namespace SB.Models.Paginator;

public class PaginatorUserDto : PaginatorBase
{
    public int? Id { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }

    public int? RoleId { get; set; }
    public bool? Activo { get; set; }
    public bool? Bloqueado { get; set; }
}

namespace SB.Entities.Base;

/// <summary>
/// Marca una entidad como persistible (tiene Id entero).
/// </summary>
public interface IEntityBase
{
    int Id { get; set; }
    /// <summary>Usuario que realizó la acción. NULL si fue anónimo (ej. login fallido).</summary>
  
}

using SB.Entities.Empleados;
using SB.Models.Dtos.RRHH;

namespace SB.Helpers.Mappers;

/// <summary>
/// Factory que decide qué subtipo de Employee instanciar a partir del DTO.
/// AutoMapper no resuelve esta decisión por sí solo (es lógica de negocio).
/// </summary>
public static class EmpleadoFactory
{
    public static Empleado CreateOrUpdateFromDto(EmpleadoDtos dto)
    {
        Empleado entity = dto.TipoEmpleadoId switch
        {
            1 => new EmpleadoAsalariado(),
            2 => new EmpleadoPorHoras(),
            3 => new EmpleadoComision(),
            4 => new BaseEmpleadoComision(),
            _ => throw new InvalidOperationException(
                $"Tipo de empleado no soportado: {dto.TipoEmpleadoId}")
        };

        entity.Nombres = dto.Nombres;
        entity.Apellidos = dto.Apellidos;
        entity.NumeroSeguroSocial = dto.NumeroSeguroSocial;
        entity.DepartmentoId = dto.DepartmentoId;
        entity.TipoEmpleadoId = dto.TipoEmpleadoId;
        entity.Activo = dto.Activo;

        entity.SalarioSemanal = dto.SalarioSemanal;
        entity.SueldoPorHora = dto.SueldoPorHora;
        entity.HorasTrabajadas = dto.HorasTrabajadas;
        entity.VentasBrutas = dto.VentasBrutas;
        entity.TarifaComision = dto.TarifaComision;
        entity.SalarioBase = dto.SalarioBase;

        return entity;
    }

    public static void ApplyChanges(Empleado entity, EmpleadoDtos dto)
    {
        entity.Nombres = dto.Nombres;
        entity.Apellidos = dto.Apellidos;
        entity.NumeroSeguroSocial = dto.NumeroSeguroSocial;
        entity.DepartmentoId = dto.DepartmentoId;
        entity.Activo = dto.Activo;

        entity.SalarioSemanal = 0;
        entity.SueldoPorHora = 0;
        entity.HorasTrabajadas = 0;
        entity.VentasBrutas = 0;
        entity.TarifaComision = 0;
        entity.SalarioBase = 0;

        switch (dto.TipoEmpleadoId)
        {
            case 1:
                entity.SalarioSemanal = dto.SalarioSemanal;
                break;

            case 2:
                entity.SueldoPorHora = dto.SueldoPorHora;
                entity.HorasTrabajadas = dto.HorasTrabajadas;
                break;

            case 3:
                entity.VentasBrutas = dto.VentasBrutas;
                entity.TarifaComision = dto.TarifaComision;
                break;

            case 4:
                entity.SalarioBase = dto.SalarioBase;
                entity.VentasBrutas = dto.VentasBrutas;
                entity.TarifaComision = dto.TarifaComision;
                break;

            default:
                throw new InvalidOperationException($"Tipo de empleado no soportado: {dto.TipoEmpleadoId}");
        }
    }
}

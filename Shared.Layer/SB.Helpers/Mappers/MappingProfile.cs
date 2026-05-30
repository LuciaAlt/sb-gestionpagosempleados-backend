using AutoMapper;
using SB.Entities.Empleados;
using SB.Entities.Seguridad;
using SB.Models.Dtos.RRHH;
using SB.Models.Dtos.Seguridad;

namespace SB.Helpers.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ─── Empleados ───────────────────────────────────────────────────
        CreateMap<Departamento, DepartmentDto>();
        CreateMap<TipoEmpleado, TipoEmpleadoDto>();

        CreateMap<Empleado, EmpleadoDtos>()
            .ForMember(d => d.DepartmentoId,
                opt => opt.MapFrom(src => src.DepartmentoId))

            .ForMember(d => d.TipoEmpleadoId,
                opt => opt.MapFrom(src => src.TipoEmpleadoId))

            .ForMember(d => d.TipoEmpleadoCodigo,
                opt => opt.MapFrom(src => src.TipoCodigo))

            .ForMember(d => d.DepartmentNombre,
                opt => opt.MapFrom(src =>
                    src.Departmento != null
                        ? src.Departmento.Nombre
                        : null))

            .ForMember(d => d.TipoEmpleadoNombre,
                opt => opt.MapFrom(src =>
                    src.TipoEmpleado != null
                        ? src.TipoEmpleado.Nombre
                        : null))

            .ForMember(d => d.SalarioSemanal,
                opt => opt.MapFrom(src => src.SalarioSemanal))

            .ForMember(d => d.SueldoPorHora,
                opt => opt.MapFrom(src => src.SueldoPorHora))

            .ForMember(d => d.HorasTrabajadas,
                opt => opt.MapFrom(src => src.HorasTrabajadas))

            .ForMember(d => d.VentasBrutas,
                opt => opt.MapFrom(src => src.VentasBrutas))

            .ForMember(d => d.TarifaComision,
                opt => opt.MapFrom(src => src.TarifaComision))

            .ForMember(d => d.SalarioBase,
                opt => opt.MapFrom(src => src.SalarioBase))

            .ForMember(d => d.PagoSemanal,
                opt => opt.Ignore());
        // ─── Seguridad ───────────────────────────────────────────────────
        CreateMap<Usuario, UsuarioDto>()
            .ForMember(d => d.RolNombre, opt => opt.MapFrom(src => src.Rol != null ? src.Rol.Nombre : null));

        CreateMap<Role, RolDto>()
            .ForMember(d => d.Permisos, opt => opt.MapFrom(src => src.RolesPermisos
                .Where(rp => rp.Permiso != null)
                .Select(rp => rp.Permiso!)));

        CreateMap<Modulo, ModuleDto>();

        CreateMap<Permiso, PermisoDto>();

        CreateMap<Auditoria, AuditoriaDto>();
    }
}

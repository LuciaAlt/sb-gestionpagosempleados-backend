using SB.Entities.Empleados;
using SB.Entities.Seguridad;
using SB.Models.Dtos.RRHH;
using SB.Models.Dtos.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Helpers.Mappers
{
    /// <summary>
    /// Factory que decide qué subtipo de Employee instanciar a partir del DTO.
    /// AutoMapper no resuelve esta decisión por sí solo (es lógica de negocio).
    /// </summary>
    public static class UsuarioFactory
    {
        public static Usuario CreateFromDto(UsuarioDto dto)
        {
            Usuario entity = new();
          
            entity.NombreUsuario = dto.NombreUsuario;
            entity.Nombres = dto.Nombres;
            entity.Apellidos = dto.Apellidos;
            entity.Correo = dto.Correo;
            entity.HashContrasena = dto.HashContrasena;
            entity.RolId = dto.RolId;
            entity.Activo = dto.Activo;
            entity.Bloqueado = dto.Bloqueado;
            entity.FechaCambioContrasena = dto.FechaCambioContrasena;
            return entity;
        }

        public static void ApplyChanges(Usuario entity, UsuarioDto dto)
        {
            entity.NombreUsuario = dto.NombreUsuario;
            entity.Nombres = dto.Nombres;
            entity.Apellidos = dto.Apellidos;
            entity.Correo = dto.Correo;
            entity.HashContrasena = dto.HashContrasena;
            entity.RolId = dto.RolId;
            entity.Activo = dto.Activo;
            entity.Bloqueado = dto.Bloqueado;
            entity.FechaCambioContrasena = dto.FechaCambioContrasena;

        }
    }
}
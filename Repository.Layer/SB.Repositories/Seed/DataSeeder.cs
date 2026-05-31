using Microsoft.EntityFrameworkCore;
using SB.Entities.Seguridad;
using SB.Models.Contracts;
using SB.Models.Enums;
using SB.Models.Helpers;
using SB.Repositories.Context;

namespace SB.Repositories.Seed;

/// <summary>
/// Inicializa la base de datos al arrancar la API.
/// 1. Aplica migraciones pendientes (db.Database.MigrateAsync()).
/// 2. Siembra 6 usuarios precargados con contraseñas hasheadas vía BCrypt
///    si la tabla [Seguridad].[Users] está vacía.
///
/// No usamos HasData para los usuarios porque BCrypt es no-determinístico:
/// generaría hashes diferentes en cada migración y EF detectaría cambios falsos.
/// El runtime seeder es la práctica estándar en templates modernos de .NET.
/// </summary>
public static class DataSeeder
{
    public static async Task InitializeAsync(SBDbContext db, IPasswordHasher hasher)
    {
        await db.Database.MigrateAsync();

        if (!await db.Usuario.AnyAsync())
        {
            var now = DateTimeOffset.Now;
            var sys = Constants.System.SystemUser;

            // ─── 2 ADMINISTRADORES (RoleId = 1) ──────────────────────────
            var administradores = new[]
            {
                new Usuario
                {
                    NombreUsuario = "admin",
                    Nombres = "Luis",
                    Apellidos = "Alcantara",
                    Correo = "admin@sb.local",
                    HashContrasena = hasher.Hash("Admin123!"),
                    RolId = (int)RoleCode.Admin,
                    UsuarioRegistra = sys,
                    FechaRegistra = now,
                    FechaCambioContrasena=DateTime.Now.AddDays(35),
                    Activo = true,
                    Bloqueado=false,
                    Borrado=false
                },
                new Usuario
                {
                    NombreUsuario = "supervisor",
                    Nombres = "Daniel",
                    Apellidos = "Rojas",
                    Correo = "supervisor@sb.local",
                    HashContrasena = hasher.Hash("Super123!"),
                    RolId = (int)RoleCode.Admin,
                    UsuarioRegistra = sys, 
                    FechaRegistra = now,
                    FechaCambioContrasena=DateTime.Now.AddDays(10),
                    Activo = true,
                    Bloqueado=false,
                    Borrado=false
                }
            };

            // ─── 4 USUARIOS NORMALES (RoleId = 2) ─────────────────────────
            var normales = new[]
            {
                new Usuario
                {
                    NombreUsuario = "jperez",
                    Nombres = "Juan",
                    Apellidos = "Perez",
                    Correo = "juan.perez@sb.local",
                    HashContrasena = hasher.Hash("Juan123!"),
                    RolId = (int)RoleCode.Usuario,
                    UsuarioRegistra = sys,
                    FechaCambioContrasena=DateTime.Now.AddDays(15),
                    FechaRegistra = now,
                    Activo = true,
                    Bloqueado=false,
                    Borrado=false
                },
                new Usuario
                {
                    NombreUsuario = "mlopez",
                    Nombres = "Maria",
                    Apellidos = "López",
                    Correo = "maria.lopez@sb.local",
                    HashContrasena = hasher.Hash("Maria123!"),
                    RolId = (int)RoleCode.Usuario,
                    UsuarioRegistra = sys,
                    FechaRegistra = now,
                    FechaCambioContrasena=DateTime.Now.AddDays(20),
                    Activo = true,
                    Bloqueado=false,
                    Borrado=false
                },
                new Usuario
                {
                    NombreUsuario = "crodriguez",
                    Nombres = "Carlos",
                    Apellidos = "Rodriguez",
                    Correo = "carlos.rodriguez@sb.local",
                    HashContrasena = hasher.Hash("Carlos123!"),
                    RolId = (int)RoleCode.Usuario,
                    UsuarioRegistra = sys,
                    FechaRegistra = now,
                    FechaCambioContrasena=DateTime.Now.AddDays(25),
                    Activo = true,
                    Bloqueado=false,
                    Borrado=false
                },
                new Usuario
                {
                    NombreUsuario = "asantos",
                    Nombres = "Antomio",
                    Apellidos = "Santos",
                    Correo = "ana.santos@sb.local",
                    HashContrasena = hasher.Hash("Ana123!"),
                    RolId = (int)RoleCode.Usuario,
                    UsuarioRegistra = sys,
                    FechaRegistra = now,
                    FechaCambioContrasena=DateTime.Now.AddDays(18),
                    Activo = true,
                    Bloqueado=false,
                    Borrado=false
                }
            };

            db.Usuario.AddRange(administradores);
            db.Usuario.AddRange(normales);
            await db.SaveChangesAsync();
        }
    }
}

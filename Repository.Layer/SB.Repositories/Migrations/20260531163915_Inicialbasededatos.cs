using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SB.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Inicialbasededatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Seguridad");

            migrationBuilder.EnsureSchema(
                name: "RRHH");

            migrationBuilder.CreateTable(
                name: "Auditoria",
                schema: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Entidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EntidadId = table.Column<int>(type: "int", nullable: true),
                    Detalle = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Fecha = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                schema: "RRHH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistra = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioModifica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModifica = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                schema: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistra = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioModifica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModifica = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistra = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioModifica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModifica = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpleado",
                schema: "RRHH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistra = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioModifica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModifica = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                schema: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistra = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioModifica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModifica = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permiso_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalSchema: "Seguridad",
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HashContrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCambioContrasena = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UltimoAcceso = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistra = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioModifica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModifica = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_RolId",
                        column: x => x.RolId,
                        principalSchema: "Seguridad",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                schema: "RRHH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroSeguroSocial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentoId = table.Column<int>(type: "int", nullable: false),
                    TipoEmpleadoId = table.Column<int>(type: "int", nullable: false),
                    SalarioSemanal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SueldoPorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorasTrabajadas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VentasBrutas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TarifaComision = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistra = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioModifica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModifica = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Departamento_DepartmentoId",
                        column: x => x.DepartmentoId,
                        principalSchema: "RRHH",
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_TipoEmpleado_TipoEmpleadoId",
                        column: x => x.TipoEmpleadoId,
                        principalSchema: "RRHH",
                        principalTable: "TipoEmpleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermisos",
                schema: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PermisoId = table.Column<int>(type: "int", nullable: false),
                    FechaConcedida = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioConcede = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioRegistra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistra = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioModifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModifica = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesPermisos_Permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalSchema: "Seguridad",
                        principalTable: "Permiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesPermisos_Roles_RolId",
                        column: x => x.RolId,
                        principalSchema: "Seguridad",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "RRHH",
                table: "Departamento",
                columns: new[] { "Id", "Activo", "Borrado", "Descripcion", "FechaModifica", "FechaRegistra", "Nombre", "UsuarioModifica", "UsuarioRegistra" },
                values: new object[,]
                {
                    { 1, true, false, "RRHH", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Recursos Humanos", null, "SYSTEM" },
                    { 2, true, false, "TI", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tecnología", null, "SYSTEM" },
                    { 3, true, false, "Comercial", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Ventas", null, "SYSTEM" },
                    { 4, true, false, "Contabilidad", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Finanzas", null, "SYSTEM" },
                    { 5, true, false, "Operaciones", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Operaciones", null, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                schema: "Seguridad",
                table: "Modulo",
                columns: new[] { "Id", "Activo", "Borrado", "Codigo", "FechaModifica", "FechaRegistra", "Icono", "Nombre", "Orden", "UsuarioModifica", "UsuarioRegistra" },
                values: new object[,]
                {
                    { 1, true, false, "001", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ti-users", "Gestión de Empleados", 1, null, "SYSTEM" },
                    { 2, true, false, "002", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ti-user-shield", "Usuarios del Sistema", 2, null, "SYSTEM" },
                    { 3, true, false, "003", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ti-report", "Reportes", 3, null, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                schema: "Seguridad",
                table: "Roles",
                columns: new[] { "Id", "Activo", "Borrado", "Codigo", "FechaModifica", "FechaRegistra", "Nombre", "UsuarioModifica", "UsuarioRegistra" },
                values: new object[,]
                {
                    { 1, true, false, "ADMIN", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Administrador", null, "SYSTEM" },
                    { 2, true, false, "USUARIO", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Usuario", null, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                schema: "RRHH",
                table: "TipoEmpleado",
                columns: new[] { "Id", "Activo", "Borrado", "Codigo", "Descripcion", "FechaModifica", "FechaRegistra", "Nombre", "UsuarioModifica", "UsuarioRegistra" },
                values: new object[,]
                {
                    { 1, true, false, "001", "Pago semanal fijo.", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Empleado Asalariado", null, "SYSTEM" },
                    { 2, true, false, "002", "Horas regulares + extras al 1.5×.", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Empleado por Horas", null, "SYSTEM" },
                    { 3, true, false, "003", "Ventas brutas × tarifa.", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Empleado por Comisión", null, "SYSTEM" },
                    { 4, true, false, "004", "Comisión + base + 10% del base.", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Empleado Asalariado por Comisión", null, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                schema: "RRHH",
                table: "Empleado",
                columns: new[] { "Id", "Activo", "Apellidos", "Borrado", "DepartmentoId", "FechaModifica", "FechaRegistra", "HorasTrabajadas", "Nombres", "NumeroSeguroSocial", "SalarioBase", "SalarioSemanal", "SueldoPorHora", "TarifaComision", "TipoEmpleadoId", "UsuarioModifica", "UsuarioRegistra", "VentasBrutas" },
                values: new object[,]
                {
                    { 1, true, "Ramírez", false, 1, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Carlos", "001-1000001-1", 0m, 1200.00m, 0m, 0m, 1, null, "SYSTEM", 0m },
                    { 2, true, "Núñez", false, 4, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Patricia", "001-1000002-2", 0m, 1850.50m, 0m, 0m, 1, null, "SYSTEM", 0m },
                    { 3, true, "Hernández", false, 2, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Luis", "001-1000003-3", 0m, 2100.00m, 0m, 0m, 1, null, "SYSTEM", 0m },
                    { 4, true, "Pérez", false, 5, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 38.00m, "Andrés", "001-2000004-4", 0m, 0m, 18.50m, 0m, 2, null, "SYSTEM", 0m },
                    { 5, true, "Castillo", false, 5, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50.00m, "Mariela", "001-2000005-5", 0m, 0m, 22.00m, 0m, 2, null, "SYSTEM", 0m },
                    { 6, true, "Mejía", false, 2, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 45.00m, "Roberto", "001-2000006-6", 0m, 0m, 25.75m, 0m, 2, null, "SYSTEM", 0m },
                    { 7, true, "Reyes", false, 3, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Sandra", "001-3000007-7", 0m, 0m, 0m, 0.05m, 3, null, "SYSTEM", 12000.00m },
                    { 8, true, "Tavárez", false, 3, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Jorge", "001-3000008-8", 0m, 0m, 0m, 0.07m, 3, null, "SYSTEM", 25500.00m },
                    { 9, false, "Marte", false, 3, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Isabel", "001-3000009-9", 0m, 0m, 0m, 0.06m, 3, null, "SYSTEM", 8750.00m },
                    { 10, true, "Vásquez", false, 3, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Elena", "001-4000010-0", 500.00m, 0m, 0m, 0.08m, 4, null, "SYSTEM", 15000.00m },
                    { 11, true, "Sosa", false, 3, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Daniel", "001-4000011-1", 800.00m, 0m, 0m, 0.06m, 4, null, "SYSTEM", 22000.00m },
                    { 12, true, "Polanco", false, 3, null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, "Karen", "001-4000012-2", 600.00m, 0m, 0m, 0.10m, 4, null, "SYSTEM", 9500.00m }
                });

            migrationBuilder.InsertData(
                schema: "Seguridad",
                table: "Permiso",
                columns: new[] { "Id", "Activo", "Borrado", "Codigo", "FechaModifica", "FechaRegistra", "ModuloId", "Nombre", "UsuarioModifica", "UsuarioRegistra" },
                values: new object[,]
                {
                    { 1, true, false, "EMPLEADOS_VER", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Ver empleados", null, "SYSTEM" },
                    { 2, true, false, "EMPLEADOS_CREAR", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Crear empleados", null, "SYSTEM" },
                    { 3, true, false, "EMPLEADOS_EDITAR", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Editar empleados", null, "SYSTEM" },
                    { 4, true, false, "EMPLEADOS_ACTIVARORDESACTIVAR", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Activa o inactivar empleados", null, "SYSTEM" },
                    { 5, true, false, "USUARIOS_VER", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Ver usuarios", null, "SYSTEM" },
                    { 6, true, false, "USUARIOS_CREAR", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Crear usuarios", null, "SYSTEM" },
                    { 7, true, false, "USUARIOS_EDITAR", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Edita usuarios", null, "SYSTEM" },
                    { 8, true, false, "USUARIOS_ACTIVARORDESACTIVAR", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Activa o inactivar usuarios", null, "SYSTEM" },
                    { 9, true, false, "USUARIOS_BLOQUEAORDESBLOQUEA", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Bloquea o desbloquea  usuarios", null, "SYSTEM" },
                    { 10, true, false, "AUDITORIA_VER", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Ver bitácora", null, "SYSTEM" },
                    { 11, true, false, "REPORTES_VER", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Ver reportes", null, "SYSTEM" },
                    { 12, true, false, "REPORTES_EXPORTAR", null, new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Exportar reportes", null, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                schema: "Seguridad",
                table: "RolesPermisos",
                columns: new[] { "Id", "Activo", "Borrado", "FechaConcedida", "FechaModifica", "FechaRegistra", "PermisoId", "RolId", "UsuarioConcede", "UsuarioModifica", "UsuarioRegistra" },
                values: new object[,]
                {
                    { 1, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, -4, 0, 0, 0)), 1, 1, "SYSTEM", null, "" },
                    { 2, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(610), new TimeSpan(0, -4, 0, 0, 0)), 2, 1, "SYSTEM", null, "" },
                    { 3, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(611), new TimeSpan(0, -4, 0, 0, 0)), 3, 1, "SYSTEM", null, "" },
                    { 4, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(613), new TimeSpan(0, -4, 0, 0, 0)), 4, 1, "SYSTEM", null, "" },
                    { 5, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(615), new TimeSpan(0, -4, 0, 0, 0)), 5, 1, "SYSTEM", null, "" },
                    { 6, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, -4, 0, 0, 0)), 6, 1, "SYSTEM", null, "" },
                    { 7, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(618), new TimeSpan(0, -4, 0, 0, 0)), 7, 1, "SYSTEM", null, "" },
                    { 8, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(619), new TimeSpan(0, -4, 0, 0, 0)), 8, 1, "SYSTEM", null, "" },
                    { 9, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(621), new TimeSpan(0, -4, 0, 0, 0)), 9, 1, "SYSTEM", null, "" },
                    { 10, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(622), new TimeSpan(0, -4, 0, 0, 0)), 10, 1, "SYSTEM", null, "" },
                    { 11, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, -4, 0, 0, 0)), 11, 1, "SYSTEM", null, "" },
                    { 12, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(625), new TimeSpan(0, -4, 0, 0, 0)), 12, 1, "SYSTEM", null, "" },
                    { 13, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(402), new TimeSpan(0, -4, 0, 0, 0)), 1, 2, "SYSTEM", null, "" },
                    { 14, true, false, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, -4, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2026, 5, 31, 12, 39, 15, 202, DateTimeKind.Unspecified).AddTicks(414), new TimeSpan(0, -4, 0, 0, 0)), 5, 2, "SYSTEM", null, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_Entidad_EntidadId",
                schema: "Seguridad",
                table: "Auditoria",
                columns: new[] { "Entidad", "EntidadId" });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_Fecha",
                schema: "Seguridad",
                table: "Auditoria",
                column: "Fecha");

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_UsuarioRegistra",
                schema: "Seguridad",
                table: "Auditoria",
                column: "UsuarioRegistra");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_Nombre",
                schema: "RRHH",
                table: "Departamento",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DepartmentoId",
                schema: "RRHH",
                table: "Empleado",
                column: "DepartmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_NumeroSeguroSocial",
                schema: "RRHH",
                table: "Empleado",
                column: "NumeroSeguroSocial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_TipoEmpleadoId",
                schema: "RRHH",
                table: "Empleado",
                column: "TipoEmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Modulo_Codigo",
                schema: "Seguridad",
                table: "Modulo",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_Codigo",
                schema: "Seguridad",
                table: "Permiso",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_ModuloId",
                schema: "Seguridad",
                table: "Permiso",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Codigo",
                schema: "Seguridad",
                table: "Roles",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermisos_PermisoId",
                schema: "Seguridad",
                table: "RolesPermisos",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermisos_RolId_PermisoId",
                schema: "Seguridad",
                table: "RolesPermisos",
                columns: new[] { "RolId", "PermisoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoEmpleado_Codigo",
                schema: "RRHH",
                table: "TipoEmpleado",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_NombreUsuario",
                schema: "Seguridad",
                table: "Usuario",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                schema: "Seguridad",
                table: "Usuario",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoria",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Empleado",
                schema: "RRHH");

            migrationBuilder.DropTable(
                name: "RolesPermisos",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Departamento",
                schema: "RRHH");

            migrationBuilder.DropTable(
                name: "TipoEmpleado",
                schema: "RRHH");

            migrationBuilder.DropTable(
                name: "Permiso",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Modulo",
                schema: "Seguridad");
        }
    }
}

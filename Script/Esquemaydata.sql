USE [SBDB]
GO
/****** Object:  Schema [RRHH]    Script Date: 5/31/2026 3:08:56 PM ******/
CREATE SCHEMA [RRHH]
GO
/****** Object:  Schema [Seguridad]    Script Date: 5/31/2026 3:08:56 PM ******/
CREATE SCHEMA [Seguridad]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RRHH].[Departamento]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RRHH].[Departamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[UsuarioRegistra] [nvarchar](50) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](50) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RRHH].[Empleado]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RRHH].[Empleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[NumeroSeguroSocial] [nvarchar](20) NOT NULL,
	[DepartmentoId] [int] NOT NULL,
	[TipoEmpleadoId] [int] NOT NULL,
	[SalarioSemanal] [decimal](18, 2) NOT NULL,
	[SueldoPorHora] [decimal](18, 2) NOT NULL,
	[HorasTrabajadas] [decimal](18, 2) NOT NULL,
	[VentasBrutas] [decimal](18, 2) NOT NULL,
	[TarifaComision] [decimal](5, 4) NOT NULL,
	[SalarioBase] [decimal](18, 2) NOT NULL,
	[UsuarioRegistra] [nvarchar](50) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](50) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RRHH].[TipoEmpleado]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RRHH].[TipoEmpleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](60) NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[UsuarioRegistra] [nvarchar](50) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](50) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoEmpleado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Auditoria]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Auditoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioRegistra] [nvarchar](50) NULL,
	[Accion] [nvarchar](40) NOT NULL,
	[Entidad] [nvarchar](80) NOT NULL,
	[EntidadId] [int] NULL,
	[Detalle] [nvarchar](2000) NULL,
	[Ip] [nvarchar](60) NULL,
	[Fecha] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Auditoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Modulo]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Modulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](40) NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[Icono] [nvarchar](120) NULL,
	[Orden] [int] NOT NULL,
	[UsuarioRegistra] [nvarchar](50) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](50) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Permiso]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuloId] [int] NOT NULL,
	[Codigo] [nvarchar](80) NOT NULL,
	[Nombre] [nvarchar](120) NOT NULL,
	[UsuarioRegistra] [nvarchar](50) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](50) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Roles]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](40) NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[UsuarioRegistra] [nvarchar](50) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](50) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[RolesPermisos]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[RolesPermisos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RolId] [int] NOT NULL,
	[PermisoId] [int] NOT NULL,
	[FechaConcedida] [datetimeoffset](7) NOT NULL,
	[UsuarioConcede] [nvarchar](50) NOT NULL,
	[UsuarioRegistra] [nvarchar](max) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](max) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_RolesPermisos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Usuario]    Script Date: 5/31/2026 3:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Nombres] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[HashContrasena] [nvarchar](255) NOT NULL,
	[RolId] [int] NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[FechaCambioContrasena] [datetimeoffset](7) NULL,
	[UltimoAcceso] [datetimeoffset](7) NULL,
	[UsuarioRegistra] [nvarchar](50) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](50) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260531163915_Inicialbasededatos', N'8.0.0')
GO
SET IDENTITY_INSERT [RRHH].[Departamento] ON 
GO
INSERT [RRHH].[Departamento] ([Id], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, N'Recursos Humanos', N'RRHH', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Departamento] ([Id], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, N'Tecnología', N'TI', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Departamento] ([Id], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, N'Ventas', N'Comercial', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Departamento] ([Id], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, N'Finanzas', N'Contabilidad', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Departamento] ([Id], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (5, N'Operaciones', N'Operaciones', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [RRHH].[Departamento] OFF
GO
SET IDENTITY_INSERT [RRHH].[Empleado] ON 
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, N'Carlos', N'Ramírez', N'001-1000001-1', 1, 1, CAST(1200.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:25:37.7381095-04:00' AS DateTimeOffset), 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, N'Patricia', N'Núñez', N'001-1000002-2', 4, 1, CAST(1850.50 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, N'Luis', N'Hernández', N'001-1000003-3', 2, 1, CAST(2100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, N'Andrés', N'Pérez', N'001-2000004-4', 5, 2, CAST(0.00 AS Decimal(18, 2)), CAST(18.50 AS Decimal(18, 2)), CAST(38.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:17:15.0687882-04:00' AS DateTimeOffset), 0, 0)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (5, N'Mariela', N'Castillo', N'001-2000005-5', 5, 2, CAST(0.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (6, N'Roberto', N'Mejía', N'001-2000006-6', 2, 2, CAST(0.00 AS Decimal(18, 2)), CAST(25.75 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (7, N'Sandra', N'Reyes', N'001-3000007-7', 3, 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), CAST(0.0500 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:23:17.4522871-04:00' AS DateTimeOffset), 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (8, N'Jorge', N'Tavárez', N'001-3000008-8', 3, 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(25500.00 AS Decimal(18, 2)), CAST(0.0700 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:23:06.1557316-04:00' AS DateTimeOffset), 0, 0)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (9, N'Isabel', N'Marte', N'001-3000009-9', 3, 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(8750.00 AS Decimal(18, 2)), CAST(0.0600 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 0)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (10, N'Elena', N'Vásquez', N'001-4000010-0', 3, 4, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), CAST(0.0800 AS Decimal(5, 4)), CAST(500.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:25:09.3412481-04:00' AS DateTimeOffset), 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (11, N'Daniel', N'Sosa', N'001-4000011-1', 3, 4, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(22000.00 AS Decimal(18, 2)), CAST(0.0600 AS Decimal(5, 4)), CAST(800.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (12, N'Karen', N'Polanco', N'001-4000012-2', 3, 4, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(9500.00 AS Decimal(18, 2)), CAST(0.1000 AS Decimal(5, 4)), CAST(600.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:17:09.6040944-04:00' AS DateTimeOffset), 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (13, N'Martin', N'Duran', N'001-1000004-4', 5, 2, CAST(0.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(132.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'admin', CAST(N'2026-05-31T14:16:04.2564858-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [RRHH].[Empleado] OFF
GO
SET IDENTITY_INSERT [RRHH].[TipoEmpleado] ON 
GO
INSERT [RRHH].[TipoEmpleado] ([Id], [Codigo], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, N'001', N'Empleado Asalariado', N'Pago semanal fijo.', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[TipoEmpleado] ([Id], [Codigo], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, N'002', N'Empleado por Horas', N'Horas regulares + extras al 1.5×.', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[TipoEmpleado] ([Id], [Codigo], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, N'003', N'Empleado por Comisión', N'Ventas brutas × tarifa.', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[TipoEmpleado] ([Id], [Codigo], [Nombre], [Descripcion], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, N'004', N'Empleado Asalariado por Comisión', N'Comisión + base + 10% del base.', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [RRHH].[TipoEmpleado] OFF
GO
SET IDENTITY_INSERT [Seguridad].[Auditoria] ON 
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (1, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482647,"Activo":true,"Apellidos":"Alcantara","Bloqueado":false,"Borrado":false,"Correo":"admin@sb.local","FechaCambioContrasena":"2026-07-05T12:39:57.0862633-04:00","HashContrasena":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia","NombreUsuario":"admin","Nombres":"Luis","RolId":1,"UltimoAcceso":null}', NULL, CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (2, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482646,"Activo":true,"Apellidos":"Rojas","Bloqueado":false,"Borrado":false,"Correo":"supervisor@sb.local","FechaCambioContrasena":"2026-06-10T12:39:57.2981228-04:00","HashContrasena":"$2a$11$X1h3vX64cQ1pCY5v1beyz.q7uSm8C0oGYxFztVp2Yn7csg/e1RLPW","NombreUsuario":"supervisor","Nombres":"Daniel","RolId":1,"UltimoAcceso":null}', NULL, CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (3, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482645,"Activo":true,"Apellidos":"Perez","Bloqueado":false,"Borrado":false,"Correo":"juan.perez@sb.local","FechaCambioContrasena":"2026-06-15T12:39:57.5150747-04:00","HashContrasena":"$2a$11$PnmFiV22znNGE4gvw2DQIuq6UelDPdt.GGVTwTomhWvYboxPE4vrG","NombreUsuario":"jperez","Nombres":"Juan","RolId":2,"UltimoAcceso":null}', NULL, CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (4, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482644,"Activo":true,"Apellidos":"L\u00F3pez","Bloqueado":false,"Borrado":false,"Correo":"maria.lopez@sb.local","FechaCambioContrasena":"2026-06-20T12:39:57.7503345-04:00","HashContrasena":"$2a$11$r8KZS1FSjAxBXtuf3ZRRaeY0JXknWdoYzEc61b0nJAj5CkJ4tciu6","NombreUsuario":"mlopez","Nombres":"Maria","RolId":2,"UltimoAcceso":null}', NULL, CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (5, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482643,"Activo":true,"Apellidos":"Rodriguez","Bloqueado":false,"Borrado":false,"Correo":"carlos.rodriguez@sb.local","FechaCambioContrasena":"2026-06-25T12:39:57.9872137-04:00","HashContrasena":"$2a$11$pXN2oxa5UQaVZVr0Q912y.4UajURu8WVs8xelWb4prtEBNOg.oiuW","NombreUsuario":"crodriguez","Nombres":"Carlos","RolId":2,"UltimoAcceso":null}', NULL, CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (6, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482642,"Activo":true,"Apellidos":"Santos","Bloqueado":false,"Borrado":false,"Correo":"ana.santos@sb.local","FechaCambioContrasena":"2026-06-18T12:39:58.2111808-04:00","HashContrasena":"$2a$11$odOPuO4oxJIKx2paNgP/C.noafIW99MCW1PED.vNFyjyyuJtMIIva","NombreUsuario":"asantos","Nombres":"Antomio","RolId":2,"UltimoAcceso":null}', NULL, CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (7, N'SYSTEM', N'UPDATE', N'Usuario', 1, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Alcantara","to":"Alcantara"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"admin@sb.local","to":"admin@sb.local"},"FechaCambioContrasena":{"from":"2026-07-05T12:39:57.0862633-04:00","to":"2026-07-05T12:39:57.0862633-04:00"},"HashContrasena":{"from":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia","to":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia"},"NombreUsuario":{"from":"admin","to":"admin"},"Nombres":{"from":"Luis","to":"Luis"},"RolId":{"from":1,"to":1},"UltimoAcceso":{"from":null,"to":"2026-05-31T16:42:07.4423399+00:00"}}', N'::1', CAST(N'2026-05-31T12:42:07.4430005-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (8, N'admin', N'LOGIN', N'Usuario', 1, N'Login exitoso. Rol: ADMIN', N'::1', CAST(N'2026-05-31T12:42:07.4697461-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (9, N'jperez', N'LOGIN_FAIL', N'Usuario', NULL, N'Intento de login fallido para ''jperez''. Motivo: Contraseña incorrecta', N'::1', CAST(N'2026-05-31T12:42:22.7794717-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (10, N'SYSTEM', N'UPDATE', N'Usuario', 3, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Perez","to":"Perez"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"juan.perez@sb.local","to":"juan.perez@sb.local"},"FechaCambioContrasena":{"from":"2026-06-15T12:39:57.5150747-04:00","to":"2026-06-15T12:39:57.5150747-04:00"},"HashContrasena":{"from":"$2a$11$PnmFiV22znNGE4gvw2DQIuq6UelDPdt.GGVTwTomhWvYboxPE4vrG","to":"$2a$11$PnmFiV22znNGE4gvw2DQIuq6UelDPdt.GGVTwTomhWvYboxPE4vrG"},"NombreUsuario":{"from":"jperez","to":"jperez"},"Nombres":{"from":"Juan","to":"Juan"},"RolId":{"from":2,"to":2},"UltimoAcceso":{"from":null,"to":"2026-05-31T16:43:05.1846127+00:00"}}', N'::1', CAST(N'2026-05-31T12:43:05.1846914-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (11, N'jperez', N'LOGIN', N'Usuario', 3, N'Login exitoso. Rol: USUARIO', N'::1', CAST(N'2026-05-31T12:43:05.1897202-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (12, N'SYSTEM', N'UPDATE', N'Usuario', 3, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Perez","to":"Perez"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"juan.perez@sb.local","to":"juan.perez@sb.local"},"FechaCambioContrasena":{"from":"2026-06-15T12:39:57.5150747-04:00","to":"2026-06-15T12:39:57.5150747-04:00"},"HashContrasena":{"from":"$2a$11$PnmFiV22znNGE4gvw2DQIuq6UelDPdt.GGVTwTomhWvYboxPE4vrG","to":"$2a$11$PnmFiV22znNGE4gvw2DQIuq6UelDPdt.GGVTwTomhWvYboxPE4vrG"},"NombreUsuario":{"from":"jperez","to":"jperez"},"Nombres":{"from":"Juan","to":"Juan"},"RolId":{"from":2,"to":2},"UltimoAcceso":{"from":"2026-05-31T16:43:05.1846127+00:00","to":"2026-05-31T16:43:28.507836+00:00"}}', N'::1', CAST(N'2026-05-31T12:43:28.5078814-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (13, N'jperez', N'LOGIN', N'Usuario', 3, N'Login exitoso. Rol: USUARIO', N'::1', CAST(N'2026-05-31T12:43:28.5137963-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (14, N'SYSTEM', N'UPDATE', N'Usuario', 1, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Alcantara","to":"Alcantara"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"admin@sb.local","to":"admin@sb.local"},"FechaCambioContrasena":{"from":"2026-07-05T12:39:57.0862633-04:00","to":"2026-07-05T12:39:57.0862633-04:00"},"HashContrasena":{"from":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia","to":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia"},"NombreUsuario":{"from":"admin","to":"admin"},"Nombres":{"from":"Luis","to":"Luis"},"RolId":{"from":1,"to":1},"UltimoAcceso":{"from":"2026-05-31T16:42:07.4423399+00:00","to":"2026-05-31T16:43:34.0773535+00:00"}}', N'::1', CAST(N'2026-05-31T12:43:34.0774585-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (15, N'admin', N'LOGIN', N'Usuario', 1, N'Login exitoso. Rol: ADMIN', N'::1', CAST(N'2026-05-31T12:43:34.0832596-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (16, N'SYSTEM', N'UPDATE', N'Usuario', 1, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Alcantara","to":"Alcantara"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"admin@sb.local","to":"admin@sb.local"},"FechaCambioContrasena":{"from":"2026-07-05T12:39:57.0862633-04:00","to":"2026-07-05T12:39:57.0862633-04:00"},"HashContrasena":{"from":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia","to":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia"},"NombreUsuario":{"from":"admin","to":"admin"},"Nombres":{"from":"Luis","to":"Luis"},"RolId":{"from":1,"to":1},"UltimoAcceso":{"from":"2026-05-31T16:43:34.0773535+00:00","to":"2026-05-31T16:57:43.8948017+00:00"}}', N'::1', CAST(N'2026-05-31T12:57:43.8949172-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (17, N'admin', N'LOGIN', N'Usuario', 1, N'Login exitoso. Rol: ADMIN', N'::1', CAST(N'2026-05-31T12:57:43.9029654-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (18, N'admin', N'UPDATE', N'BaseEmpleadoComision', 12, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Polanco","to":"Polanco"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":3,"to":3},"HorasTrabajadas":{"from":0.00,"to":0},"Nombres":{"from":"Karen","to":"Karen"},"NumeroSeguroSocial":{"from":"001-4000012-2","to":"001-4000012-2"},"SalarioBase":{"from":600.00,"to":600},"SalarioSemanal":{"from":0.00,"to":0},"SueldoPorHora":{"from":0.00,"to":0},"TarifaComision":{"from":0.1000,"to":0.1},"TipoEmpleadoId":{"from":4,"to":4},"VentasBrutas":{"from":9500.00,"to":9500}}', N'::1', CAST(N'2026-05-31T13:00:48.1924053-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (19, N'SYSTEM', N'UPDATE', N'Usuario', 1, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Alcantara","to":"Alcantara"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"admin@sb.local","to":"admin@sb.local"},"FechaCambioContrasena":{"from":"2026-07-05T12:39:57.0862633-04:00","to":"2026-07-05T12:39:57.0862633-04:00"},"HashContrasena":{"from":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia","to":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia"},"NombreUsuario":{"from":"admin","to":"admin"},"Nombres":{"from":"Luis","to":"Luis"},"RolId":{"from":1,"to":1},"UltimoAcceso":{"from":"2026-05-31T16:57:43.8948017+00:00","to":"2026-05-31T17:57:43.5998405+00:00"}}', N'::1', CAST(N'2026-05-31T13:57:43.6074130-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (20, N'admin', N'LOGIN', N'Usuario', 1, N'Login exitoso. Rol: ADMIN', N'::1', CAST(N'2026-05-31T13:57:43.7742986-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (21, N'SYSTEM', N'UPDATE', N'Usuario', 1, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Alcantara","to":"Alcantara"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"admin@sb.local","to":"admin@sb.local"},"FechaCambioContrasena":{"from":"2026-07-05T12:39:57.0862633-04:00","to":"2026-07-05T12:39:57.0862633-04:00"},"HashContrasena":{"from":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia","to":"$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia"},"NombreUsuario":{"from":"admin","to":"admin"},"Nombres":{"from":"Luis","to":"Luis"},"RolId":{"from":1,"to":1},"UltimoAcceso":{"from":"2026-05-31T17:57:43.5998405+00:00","to":"2026-05-31T18:13:24.3539082+00:00"}}', N'::1', CAST(N'2026-05-31T14:13:24.3599394-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (22, N'admin', N'LOGIN', N'Usuario', 1, N'Login exitoso. Rol: ADMIN', N'::1', CAST(N'2026-05-31T14:13:24.4908945-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (23, N'admin', N'CREATE', N'EmpleadoPorHoras', 0, N'{"Id":-2147482647,"Activo":true,"Apellidos":"Duran","Borrado":false,"DepartmentoId":5,"HorasTrabajadas":132,"Nombres":"Martin","NumeroSeguroSocial":"001-1000004-4","SalarioBase":0,"SalarioSemanal":0,"SueldoPorHora":500,"TarifaComision":0,"TipoEmpleadoId":2,"VentasBrutas":0}', N'::1', CAST(N'2026-05-31T14:16:04.2564858-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (24, N'admin', N'UPDATE', N'BaseEmpleadoComision', 12, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Polanco","to":"Polanco"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":3,"to":3},"HorasTrabajadas":{"from":0.00,"to":0},"Nombres":{"from":"Karen","to":"Karen"},"NumeroSeguroSocial":{"from":"001-4000012-2","to":"001-4000012-2"},"SalarioBase":{"from":600.00,"to":600},"SalarioSemanal":{"from":0.00,"to":0},"SueldoPorHora":{"from":0.00,"to":0},"TarifaComision":{"from":0.1000,"to":0.1},"TipoEmpleadoId":{"from":4,"to":4},"VentasBrutas":{"from":9500.00,"to":9500}}', N'::1', CAST(N'2026-05-31T14:17:09.6040944-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (25, N'admin', N'UPDATE', N'EmpleadoPorHoras', 4, N'{"Activo":{"from":true,"to":false},"Apellidos":{"from":"P\u00E9rez","to":"P\u00E9rez"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":5,"to":5},"HorasTrabajadas":{"from":38.00,"to":38.00},"Nombres":{"from":"Andr\u00E9s","to":"Andr\u00E9s"},"NumeroSeguroSocial":{"from":"001-2000004-4","to":"001-2000004-4"},"SalarioBase":{"from":0.00,"to":0.00},"SalarioSemanal":{"from":0.00,"to":0.00},"SueldoPorHora":{"from":18.50,"to":18.50},"TarifaComision":{"from":0.0000,"to":0.0000},"TipoEmpleadoId":{"from":2,"to":2},"VentasBrutas":{"from":0.00,"to":0.00}}', N'::1', CAST(N'2026-05-31T14:17:15.0687882-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (26, N'admin', N'UPDATE', N'EmpleadoComision', 8, N'{"Activo":{"from":true,"to":false},"Apellidos":{"from":"Tav\u00E1rez","to":"Tav\u00E1rez"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":3,"to":3},"HorasTrabajadas":{"from":0.00,"to":0.00},"Nombres":{"from":"Jorge","to":"Jorge"},"NumeroSeguroSocial":{"from":"001-3000008-8","to":"001-3000008-8"},"SalarioBase":{"from":0.00,"to":0.00},"SalarioSemanal":{"from":0.00,"to":0.00},"SueldoPorHora":{"from":0.00,"to":0.00},"TarifaComision":{"from":0.0700,"to":0.0700},"TipoEmpleadoId":{"from":3,"to":3},"VentasBrutas":{"from":25500.00,"to":25500.00}}', N'::1', CAST(N'2026-05-31T14:17:26.3072379-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (27, N'admin', N'UPDATE', N'Usuario', 5, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Rodriguez","to":"Rodriguez"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"carlos.rodriguez@sb.local","to":"carlos.rodriguez@sb.local"},"FechaCambioContrasena":{"from":"2026-06-25T12:39:57.9872137-04:00","to":null},"HashContrasena":{"from":"$2a$11$pXN2oxa5UQaVZVr0Q912y.4UajURu8WVs8xelWb4prtEBNOg.oiuW","to":""},"NombreUsuario":{"from":"crodriguez","to":"crodriguez"},"Nombres":{"from":"Carlos","to":"Carlos"},"RolId":{"from":2,"to":2},"UltimoAcceso":{"from":null,"to":null}}', N'::1', CAST(N'2026-05-31T14:17:33.3896311-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (28, N'admin', N'UPDATE', N'Usuario', 2, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Rojas","to":"Rojas"},"Bloqueado":{"from":false,"to":true},"Borrado":{"from":false,"to":false},"Correo":{"from":"supervisor@sb.local","to":"supervisor@sb.local"},"FechaCambioContrasena":{"from":"2026-06-10T12:39:57.2981228-04:00","to":"2026-06-10T12:39:57.2981228-04:00"},"HashContrasena":{"from":"$2a$11$X1h3vX64cQ1pCY5v1beyz.q7uSm8C0oGYxFztVp2Yn7csg/e1RLPW","to":"$2a$11$X1h3vX64cQ1pCY5v1beyz.q7uSm8C0oGYxFztVp2Yn7csg/e1RLPW"},"NombreUsuario":{"from":"supervisor","to":"supervisor"},"Nombres":{"from":"Daniel","to":"Daniel"},"RolId":{"from":1,"to":1},"UltimoAcceso":{"from":null,"to":null}}', N'::1', CAST(N'2026-05-31T14:17:43.5018509-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (29, N'admin', N'UPDATE', N'Usuario', 3, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Perez","to":"Perez"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"juan.perez@sb.local","to":"juan.perez@sb.local"},"FechaCambioContrasena":{"from":"2026-06-15T12:39:57.5150747-04:00","to":null},"HashContrasena":{"from":"$2a$11$PnmFiV22znNGE4gvw2DQIuq6UelDPdt.GGVTwTomhWvYboxPE4vrG","to":""},"NombreUsuario":{"from":"jperez","to":"jperez"},"Nombres":{"from":"Juan","to":"Juan"},"RolId":{"from":2,"to":2},"UltimoAcceso":{"from":"2026-05-31T16:43:28.507836+00:00","to":"2026-05-31T16:43:28.507836+00:00"}}', N'::1', CAST(N'2026-05-31T14:19:27.9672366-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (30, N'admin', N'UPDATE', N'Usuario', 3, N'{"Activo":{"from":true,"to":false},"Apellidos":{"from":"Perez","to":"Perez"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"juan.perez@sb.local","to":"juan.perez@sb.local"},"FechaCambioContrasena":{"from":null,"to":null},"HashContrasena":{"from":"","to":""},"NombreUsuario":{"from":"jperez","to":"jperez"},"Nombres":{"from":"Juan","to":"Juan"},"RolId":{"from":2,"to":2},"UltimoAcceso":{"from":"2026-05-31T16:43:28.507836+00:00","to":"2026-05-31T16:43:28.507836+00:00"}}', N'::1', CAST(N'2026-05-31T14:19:33.5920111-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (31, N'admin', N'UPDATE', N'EmpleadoComision', 8, N'{"Activo":{"from":false,"to":true},"Apellidos":{"from":"Tav\u00E1rez","to":"Tav\u00E1rez"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":3,"to":3},"HorasTrabajadas":{"from":0.00,"to":0.00},"Nombres":{"from":"Jorge","to":"Jorge"},"NumeroSeguroSocial":{"from":"001-3000008-8","to":"001-3000008-8"},"SalarioBase":{"from":0.00,"to":0.00},"SalarioSemanal":{"from":0.00,"to":0.00},"SueldoPorHora":{"from":0.00,"to":0.00},"TarifaComision":{"from":0.0700,"to":0.0700},"TipoEmpleadoId":{"from":3,"to":3},"VentasBrutas":{"from":25500.00,"to":25500.00}}', N'::1', CAST(N'2026-05-31T14:19:46.9927039-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (32, N'admin', N'UPDATE', N'EmpleadoComision', 8, N'{"Activo":{"from":true,"to":false},"Apellidos":{"from":"Tav\u00E1rez","to":"Tav\u00E1rez"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":3,"to":3},"HorasTrabajadas":{"from":0.00,"to":0.00},"Nombres":{"from":"Jorge","to":"Jorge"},"NumeroSeguroSocial":{"from":"001-3000008-8","to":"001-3000008-8"},"SalarioBase":{"from":0.00,"to":0.00},"SalarioSemanal":{"from":0.00,"to":0.00},"SueldoPorHora":{"from":0.00,"to":0.00},"TarifaComision":{"from":0.0700,"to":0.0700},"TipoEmpleadoId":{"from":3,"to":3},"VentasBrutas":{"from":25500.00,"to":25500.00}}', N'::1', CAST(N'2026-05-31T14:23:06.1557316-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (33, N'admin', N'UPDATE', N'EmpleadoComision', 7, N'{"Activo":{"from":true,"to":false},"Apellidos":{"from":"Reyes","to":"Reyes"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":3,"to":3},"HorasTrabajadas":{"from":0.00,"to":0.00},"Nombres":{"from":"Sandra","to":"Sandra"},"NumeroSeguroSocial":{"from":"001-3000007-7","to":"001-3000007-7"},"SalarioBase":{"from":0.00,"to":0.00},"SalarioSemanal":{"from":0.00,"to":0.00},"SueldoPorHora":{"from":0.00,"to":0.00},"TarifaComision":{"from":0.0500,"to":0.0500},"TipoEmpleadoId":{"from":3,"to":3},"VentasBrutas":{"from":12000.00,"to":12000.00}}', N'::1', CAST(N'2026-05-31T14:23:13.8908512-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (34, N'admin', N'UPDATE', N'EmpleadoComision', 7, N'{"Activo":{"from":false,"to":true},"Apellidos":{"from":"Reyes","to":"Reyes"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":3,"to":3},"HorasTrabajadas":{"from":0.00,"to":0.00},"Nombres":{"from":"Sandra","to":"Sandra"},"NumeroSeguroSocial":{"from":"001-3000007-7","to":"001-3000007-7"},"SalarioBase":{"from":0.00,"to":0.00},"SalarioSemanal":{"from":0.00,"to":0.00},"SueldoPorHora":{"from":0.00,"to":0.00},"TarifaComision":{"from":0.0500,"to":0.0500},"TipoEmpleadoId":{"from":3,"to":3},"VentasBrutas":{"from":12000.00,"to":12000.00}}', N'::1', CAST(N'2026-05-31T14:23:17.4522871-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (35, N'admin', N'UPDATE', N'BaseEmpleadoComision', 10, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"V\u00E1squez","to":"V\u00E1squez"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":3,"to":3},"HorasTrabajadas":{"from":0.00,"to":0},"Nombres":{"from":"Elena","to":"Elena"},"NumeroSeguroSocial":{"from":"001-4000010-0","to":"001-4000010-0"},"SalarioBase":{"from":500.00,"to":500},"SalarioSemanal":{"from":0.00,"to":0},"SueldoPorHora":{"from":0.00,"to":0},"TarifaComision":{"from":0.0800,"to":0.08},"TipoEmpleadoId":{"from":4,"to":4},"VentasBrutas":{"from":15000.00,"to":15000}}', N'::1', CAST(N'2026-05-31T14:25:09.3412481-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (36, N'admin', N'UPDATE', N'EmpleadoAsalariado', 1, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Ram\u00EDrez","to":"Ram\u00EDrez"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":1,"to":1},"HorasTrabajadas":{"from":0.00,"to":0},"Nombres":{"from":"Carlos","to":"Carlos"},"NumeroSeguroSocial":{"from":"001-1000001-1","to":"001-1000001-1"},"SalarioBase":{"from":0.00,"to":0},"SalarioSemanal":{"from":1200.00,"to":1200},"SueldoPorHora":{"from":0.00,"to":0},"TarifaComision":{"from":0.0000,"to":0},"TipoEmpleadoId":{"from":1,"to":1},"VentasBrutas":{"from":0.00,"to":0}}', N'::1', CAST(N'2026-05-31T14:25:37.7381095-04:00' AS DateTimeOffset))
GO
SET IDENTITY_INSERT [Seguridad].[Auditoria] OFF
GO
SET IDENTITY_INSERT [Seguridad].[Modulo] ON 
GO
INSERT [Seguridad].[Modulo] ([Id], [Codigo], [Nombre], [Icono], [Orden], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, N'001', N'Gestión de Empleados', N'ti-users', 1, N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Modulo] ([Id], [Codigo], [Nombre], [Icono], [Orden], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, N'002', N'Usuarios del Sistema', N'ti-user-shield', 2, N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Modulo] ([Id], [Codigo], [Nombre], [Icono], [Orden], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, N'003', N'Reportes', N'ti-report', 3, N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [Seguridad].[Modulo] OFF
GO
SET IDENTITY_INSERT [Seguridad].[Permiso] ON 
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 1, N'EMPLEADOS_VER', N'Ver empleados', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, 1, N'EMPLEADOS_CREAR', N'Crear empleados', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, 1, N'EMPLEADOS_EDITAR', N'Editar empleados', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, 1, N'EMPLEADOS_ACTIVARORDESACTIVAR', N'Activa o inactivar empleados', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (5, 2, N'USUARIOS_VER', N'Ver usuarios', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (6, 2, N'USUARIOS_CREAR', N'Crear usuarios', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (7, 2, N'USUARIOS_EDITAR', N'Edita usuarios', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (8, 2, N'USUARIOS_ACTIVARORDESACTIVAR', N'Activa o inactivar usuarios', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (9, 2, N'USUARIOS_BLOQUEAORDESBLOQUEA', N'Bloquea o desbloquea  usuarios', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (10, 2, N'AUDITORIA_VER', N'Ver bitácora', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (11, 3, N'REPORTES_VER', N'Ver reportes', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (12, 3, N'REPORTES_EXPORTAR', N'Exportar reportes', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [Seguridad].[Permiso] OFF
GO
SET IDENTITY_INSERT [Seguridad].[Roles] ON 
GO
INSERT [Seguridad].[Roles] ([Id], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, N'ADMIN', N'Administrador', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Roles] ([Id], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, N'USUARIO', N'Usuario', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [Seguridad].[Roles] OFF
GO
SET IDENTITY_INSERT [Seguridad].[RolesPermisos] ON 
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 1, 1, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020605-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, 1, 2, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020610-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, 1, 3, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020611-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, 1, 4, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020613-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (5, 1, 5, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020615-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (6, 1, 6, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020616-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (7, 1, 7, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020618-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (8, 1, 8, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020619-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (9, 1, 9, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020621-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (10, 1, 10, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020622-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (11, 1, 11, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020624-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (12, 1, 12, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020625-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (13, 2, 1, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020402-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([Id], [RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (14, 2, 5, CAST(N'2026-05-31T12:39:15.2020005-04:00' AS DateTimeOffset), N'SYSTEM', N'', CAST(N'2026-05-31T12:39:15.2020414-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [Seguridad].[RolesPermisos] OFF
GO
SET IDENTITY_INSERT [Seguridad].[Usuario] ON 
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, N'admin', N'Luis', N'Alcantara', N'admin@sb.local', N'$2a$11$mhCtJ5X1HvnfTdnzxx7Df.8mRf6YpEU7RDxrujEVR6uRT.Z00m1ia', 1, 0, CAST(N'2026-07-05T12:39:57.0862633-04:00' AS DateTimeOffset), CAST(N'2026-05-31T18:13:24.3539082+00:00' AS DateTimeOffset), N'SYSTEM', CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset), N'SYSTEM', CAST(N'2026-05-31T14:13:24.3599394-04:00' AS DateTimeOffset), 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, N'supervisor', N'Daniel', N'Rojas', N'supervisor@sb.local', N'$2a$11$X1h3vX64cQ1pCY5v1beyz.q7uSm8C0oGYxFztVp2Yn7csg/e1RLPW', 1, 1, CAST(N'2026-06-10T12:39:57.2981228-04:00' AS DateTimeOffset), NULL, N'SYSTEM', CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:17:43.5018509-04:00' AS DateTimeOffset), 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, N'jperez', N'Juan', N'Perez', N'juan.perez@sb.local', N'', 2, 0, NULL, CAST(N'2026-05-31T16:43:28.5078360+00:00' AS DateTimeOffset), N'SYSTEM', CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:19:33.5920111-04:00' AS DateTimeOffset), 0, 0)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, N'mlopez', N'Maria', N'López', N'maria.lopez@sb.local', N'$2a$11$r8KZS1FSjAxBXtuf3ZRRaeY0JXknWdoYzEc61b0nJAj5CkJ4tciu6', 2, 0, CAST(N'2026-06-20T12:39:57.7503345-04:00' AS DateTimeOffset), NULL, N'SYSTEM', CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (5, N'crodriguez', N'Carlos', N'Rodriguez', N'carlos.rodriguez@sb.local', N'', 2, 0, NULL, NULL, N'SYSTEM', CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-31T14:17:33.3896311-04:00' AS DateTimeOffset), 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (6, N'asantos', N'Antomio', N'Santos', N'ana.santos@sb.local', N'$2a$11$odOPuO4oxJIKx2paNgP/C.noafIW99MCW1PED.vNFyjyyuJtMIIva', 2, 0, CAST(N'2026-06-18T12:39:58.2111808-04:00' AS DateTimeOffset), NULL, N'SYSTEM', CAST(N'2026-05-31T12:39:58.2953698-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [Seguridad].[Usuario] OFF
GO
ALTER TABLE [RRHH].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Departamento_DepartmentoId] FOREIGN KEY([DepartmentoId])
REFERENCES [RRHH].[Departamento] ([Id])
GO
ALTER TABLE [RRHH].[Empleado] CHECK CONSTRAINT [FK_Empleado_Departamento_DepartmentoId]
GO
ALTER TABLE [RRHH].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_TipoEmpleado_TipoEmpleadoId] FOREIGN KEY([TipoEmpleadoId])
REFERENCES [RRHH].[TipoEmpleado] ([Id])
GO
ALTER TABLE [RRHH].[Empleado] CHECK CONSTRAINT [FK_Empleado_TipoEmpleado_TipoEmpleadoId]
GO
ALTER TABLE [Seguridad].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_Modulo_ModuloId] FOREIGN KEY([ModuloId])
REFERENCES [Seguridad].[Modulo] ([Id])
GO
ALTER TABLE [Seguridad].[Permiso] CHECK CONSTRAINT [FK_Permiso_Modulo_ModuloId]
GO
ALTER TABLE [Seguridad].[RolesPermisos]  WITH CHECK ADD  CONSTRAINT [FK_RolesPermisos_Permiso_PermisoId] FOREIGN KEY([PermisoId])
REFERENCES [Seguridad].[Permiso] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Seguridad].[RolesPermisos] CHECK CONSTRAINT [FK_RolesPermisos_Permiso_PermisoId]
GO
ALTER TABLE [Seguridad].[RolesPermisos]  WITH CHECK ADD  CONSTRAINT [FK_RolesPermisos_Roles_RolId] FOREIGN KEY([RolId])
REFERENCES [Seguridad].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Seguridad].[RolesPermisos] CHECK CONSTRAINT [FK_RolesPermisos_Roles_RolId]
GO
ALTER TABLE [Seguridad].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Roles_RolId] FOREIGN KEY([RolId])
REFERENCES [Seguridad].[Roles] ([Id])
GO
ALTER TABLE [Seguridad].[Usuario] CHECK CONSTRAINT [FK_Usuario_Roles_RolId]
GO

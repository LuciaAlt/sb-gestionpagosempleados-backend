USE [SBDB]
GO
/****** Object:  Schema [RRHH]    Script Date: 5/29/2026 7:42:27 PM ******/
CREATE SCHEMA [RRHH]
GO
/****** Object:  Schema [Seguridad]    Script Date: 5/29/2026 7:42:27 PM ******/
CREATE SCHEMA [Seguridad]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/29/2026 7:42:27 PM ******/
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
/****** Object:  Table [RRHH].[Departamento]    Script Date: 5/29/2026 7:42:27 PM ******/
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
/****** Object:  Table [RRHH].[Empleado]    Script Date: 5/29/2026 7:42:27 PM ******/
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
/****** Object:  Table [RRHH].[TipoEmpleado]    Script Date: 5/29/2026 7:42:27 PM ******/
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
/****** Object:  Table [Seguridad].[Auditoria]    Script Date: 5/29/2026 7:42:27 PM ******/
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
/****** Object:  Table [Seguridad].[Modulo]    Script Date: 5/29/2026 7:42:27 PM ******/
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
/****** Object:  Table [Seguridad].[Permiso]    Script Date: 5/29/2026 7:42:27 PM ******/
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
/****** Object:  Table [Seguridad].[Roles]    Script Date: 5/29/2026 7:42:27 PM ******/
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
/****** Object:  Table [Seguridad].[RolesPermisos]    Script Date: 5/29/2026 7:42:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[RolesPermisos](
	[RolId] [int] NOT NULL,
	[PermisoId] [int] NOT NULL,
	[FechaConcedida] [datetimeoffset](7) NOT NULL,
	[UsuarioConcede] [nvarchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[UsuarioRegistra] [nvarchar](max) NOT NULL,
	[FechaRegistra] [datetimeoffset](7) NOT NULL,
	[UsuarioModifica] [nvarchar](max) NULL,
	[FechaModifica] [datetimeoffset](7) NULL,
	[Borrado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_RolesPermisos] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC,
	[PermisoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Usuario]    Script Date: 5/29/2026 7:42:27 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260529231213_inicialbasededatosSB', N'8.0.0')
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
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, N'Carlos', N'Ramírez', N'001-1000001-1', 1, 1, CAST(1200.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, N'Patricia', N'Núñez', N'001-1000002-2', 4, 1, CAST(1850.50 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, N'Luis', N'Hernández', N'001-1000003-3', 2, 1, CAST(2100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, N'Andrés', N'Pérez', N'001-2000004-4', 5, 2, CAST(0.00 AS Decimal(18, 2)), CAST(18.50 AS Decimal(18, 2)), CAST(38.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (5, N'Mariela', N'Castillo', N'001-2000005-5', 5, 2, CAST(0.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (6, N'Roberto', N'Mejía', N'001-2000006-6', 2, 2, CAST(0.00 AS Decimal(18, 2)), CAST(25.75 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (7, N'Sandra', N'Reyes', N'001-3000007-7', 3, 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), CAST(0.0500 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (8, N'Jorge', N'Tavárez', N'001-3000008-8', 3, 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(25500.00 AS Decimal(18, 2)), CAST(0.0700 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (9, N'Isabel', N'Marte', N'001-3000009-9', 3, 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(8750.00 AS Decimal(18, 2)), CAST(0.0600 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 0)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (10, N'Elena', N'Vásquez', N'001-4000010-0', 3, 4, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), CAST(0.0800 AS Decimal(5, 4)), CAST(500.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (11, N'Daniel', N'Sosa', N'001-4000011-1', 3, 4, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(22000.00 AS Decimal(18, 2)), CAST(0.0600 AS Decimal(5, 4)), CAST(800.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (12, N'Karen', N'Polanco', N'001-4000012-2', 3, 4, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(9500.00 AS Decimal(18, 2)), CAST(0.1000 AS Decimal(5, 4)), CAST(600.00 AS Decimal(18, 2)), N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [RRHH].[Empleado] ([Id], [Nombres], [Apellidos], [NumeroSeguroSocial], [DepartmentoId], [TipoEmpleadoId], [SalarioSemanal], [SueldoPorHora], [HorasTrabajadas], [VentasBrutas], [TarifaComision], [SalarioBase], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (13, N'Alejandro', N'Martínez Perez', N'001-9000001-1', 1, 1, CAST(5000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0000 AS Decimal(5, 4)), CAST(0.00 AS Decimal(18, 2)), N'admin', CAST(N'2026-05-29T19:18:57.1649950-04:00' AS DateTimeOffset), N'admin', CAST(N'2026-05-29T19:34:51.8184919-04:00' AS DateTimeOffset), 0, 1)
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
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (1, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482647,"Activo":true,"Apellidos":"Alcantara","Bloqueado":false,"Borrado":false,"Correo":"admin@sb.local","FechaCambioContrasena":"2026-07-03T19:13:33.2208133-04:00","HashContrasena":"$2a$11$zQE3LvtnbGu9DzbDK5IOOe5pMrW7sFWHGaOTKjn4QQCPF69nEcZvG","NombreUsuario":"admin","Nombres":"Luis","RolId":1,"UltimoAcceso":null}', NULL, CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (2, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482646,"Activo":true,"Apellidos":"Rojas","Bloqueado":false,"Borrado":false,"Correo":"supervisor@sb.local","FechaCambioContrasena":"2026-06-08T19:13:33.6691481-04:00","HashContrasena":"$2a$11$10UOw0pXo6/caHUrwYoriOeYcDyVGrJAOfxT3D/7vFrvQnyLqu7JG","NombreUsuario":"supervisor","Nombres":"Daniel","RolId":1,"UltimoAcceso":null}', NULL, CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (3, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482645,"Activo":true,"Apellidos":"Perez","Bloqueado":false,"Borrado":false,"Correo":"juan.perez@sb.local","FechaCambioContrasena":"2026-06-13T19:13:33.9335003-04:00","HashContrasena":"$2a$11$7mMqUdsiFYY0cA8P5RTFvu.QkUlGK3giHdvJNa3wGbEvnj23Asz9y","NombreUsuario":"jperez","Nombres":"Juan","RolId":2,"UltimoAcceso":null}', NULL, CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (4, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482644,"Activo":true,"Apellidos":"L\u00F3pez","Bloqueado":false,"Borrado":false,"Correo":"maria.lopez@sb.local","FechaCambioContrasena":"2026-06-18T19:13:34.1567196-04:00","HashContrasena":"$2a$11$g7CS6d5JXl.NFO3xv0/MuO5dOkz0k1.qh4kKGLZoQOPZ9gKJm/g5q","NombreUsuario":"mlopez","Nombres":"Maria","RolId":2,"UltimoAcceso":null}', NULL, CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (5, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482643,"Activo":true,"Apellidos":"Rodriguez","Bloqueado":false,"Borrado":false,"Correo":"carlos.rodriguez@sb.local","FechaCambioContrasena":"2026-06-23T19:13:34.3800482-04:00","HashContrasena":"$2a$11$vS6u4II.X9fTb8pzkLYsN.Y9YvVib3mKYuDqMrh7JDoFY8anjH5mC","NombreUsuario":"crodriguez","Nombres":"Carlos","RolId":2,"UltimoAcceso":null}', NULL, CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (6, N'SYSTEM', N'CREATE', N'Usuario', 0, N'{"Id":-2147482642,"Activo":true,"Apellidos":"Santos","Bloqueado":false,"Borrado":false,"Correo":"ana.santos@sb.local","FechaCambioContrasena":"2026-06-16T19:13:34.6036662-04:00","HashContrasena":"$2a$11$UvqJren/2N0cI5gSlkH36Owd7OevleQl2wg2SKXSSw1c7jNBeBVfu","NombreUsuario":"asantos","Nombres":"Antomio","RolId":2,"UltimoAcceso":null}', NULL, CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (7, N'SYSTEM', N'UPDATE', N'Usuario', 1, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Alcantara","to":"Alcantara"},"Bloqueado":{"from":false,"to":false},"Borrado":{"from":false,"to":false},"Correo":{"from":"admin@sb.local","to":"admin@sb.local"},"FechaCambioContrasena":{"from":"2026-07-03T19:13:33.2208133-04:00","to":"2026-07-03T19:13:33.2208133-04:00"},"HashContrasena":{"from":"$2a$11$zQE3LvtnbGu9DzbDK5IOOe5pMrW7sFWHGaOTKjn4QQCPF69nEcZvG","to":"$2a$11$zQE3LvtnbGu9DzbDK5IOOe5pMrW7sFWHGaOTKjn4QQCPF69nEcZvG"},"NombreUsuario":{"from":"admin","to":"admin"},"Nombres":{"from":"Luis","to":"Luis"},"RolId":{"from":1,"to":1},"UltimoAcceso":{"from":null,"to":"2026-05-29T23:14:03.4567539+00:00"}}', N'::1', CAST(N'2026-05-29T19:14:03.4579829-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (8, N'admin', N'LOGIN', N'Usuario', 1, N'Login exitoso. Rol: ADMIN', N'::1', CAST(N'2026-05-29T19:14:03.5042159-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (9, N'admin', N'CREATE', N'EmpleadoAsalariado', 0, N'{"Id":-2147482647,"Activo":true,"Apellidos":"Mart\u00EDnez","Borrado":false,"DepartmentoId":1,"HorasTrabajadas":0,"Nombres":"Alejandro","NumeroSeguroSocial":"001-9000001-1","SalarioBase":0,"SalarioSemanal":4000,"SueldoPorHora":0,"TarifaComision":0,"TipoEmpleadoId":1,"VentasBrutas":0}', N'::1', CAST(N'2026-05-29T19:18:57.1649950-04:00' AS DateTimeOffset))
GO
INSERT [Seguridad].[Auditoria] ([Id], [UsuarioRegistra], [Accion], [Entidad], [EntidadId], [Detalle], [Ip], [Fecha]) VALUES (22, N'admin', N'UPDATE', N'EmpleadoAsalariado', 13, N'{"Activo":{"from":true,"to":true},"Apellidos":{"from":"Mart\u00EDnez","to":"Mart\u00EDnez Perez"},"Borrado":{"from":false,"to":false},"DepartmentoId":{"from":1,"to":1},"HorasTrabajadas":{"from":0.00,"to":0},"Nombres":{"from":"Alejandro","to":"Alejandro"},"NumeroSeguroSocial":{"from":"001-9000001-1","to":"001-9000001-1"},"SalarioBase":{"from":0.00,"to":0},"SalarioSemanal":{"from":4000.00,"to":5000},"SueldoPorHora":{"from":0.00,"to":0},"TarifaComision":{"from":0.0000,"to":0},"TipoEmpleadoId":{"from":1,"to":1},"VentasBrutas":{"from":0.00,"to":0}}', N'::1', CAST(N'2026-05-29T19:34:51.8184919-04:00' AS DateTimeOffset))
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
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, 1, N'EMPLEADOS_INACTIVAR', N'Inactivar empleados', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (5, 3, N'REPORTES_VER', N'Ver reportes', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (6, 3, N'REPORTES_EXPORTAR', N'Exportar reportes', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (7, 2, N'USUARIOS_VER', N'Ver usuarios', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (8, 2, N'USUARIOS_CREAR', N'Crear usuarios', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Permiso] ([Id], [ModuloId], [Codigo], [Nombre], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (9, 2, N'AUDITORIA_VER', N'Ver bitácora', N'SYSTEM', CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 0, 1)
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
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 1, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 1, N'', CAST(N'2026-05-29T19:12:12.7382631-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 2, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 2, N'', CAST(N'2026-05-29T19:12:12.7382700-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 3, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 3, N'', CAST(N'2026-05-29T19:12:12.7382704-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 4, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 4, N'', CAST(N'2026-05-29T19:12:12.7382706-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 5, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 5, N'', CAST(N'2026-05-29T19:12:12.7382709-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 6, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 6, N'', CAST(N'2026-05-29T19:12:12.7382711-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 7, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 7, N'', CAST(N'2026-05-29T19:12:12.7382713-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 8, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 8, N'', CAST(N'2026-05-29T19:12:12.7382715-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, 9, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 9, N'', CAST(N'2026-05-29T19:12:12.7382717-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, 1, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 100, N'', CAST(N'2026-05-29T19:12:12.7382297-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, 5, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 101, N'', CAST(N'2026-05-29T19:12:12.7382317-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[RolesPermisos] ([RolId], [PermisoId], [FechaConcedida], [UsuarioConcede], [Id], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, 6, CAST(N'2024-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'SYSTEM', 102, N'', CAST(N'2026-05-29T19:12:12.7382321-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [Seguridad].[Usuario] ON 
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (1, N'admin', N'Luis', N'Alcantara', N'admin@sb.local', N'$2a$11$zQE3LvtnbGu9DzbDK5IOOe5pMrW7sFWHGaOTKjn4QQCPF69nEcZvG', 1, 0, CAST(N'2026-07-03T19:13:33.2208133-04:00' AS DateTimeOffset), CAST(N'2026-05-29T23:14:03.4567539+00:00' AS DateTimeOffset), N'SYSTEM', CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset), N'SYSTEM', CAST(N'2026-05-29T19:14:03.4579829-04:00' AS DateTimeOffset), 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (2, N'supervisor', N'Daniel', N'Rojas', N'supervisor@sb.local', N'$2a$11$10UOw0pXo6/caHUrwYoriOeYcDyVGrJAOfxT3D/7vFrvQnyLqu7JG', 1, 0, CAST(N'2026-06-08T19:13:33.6691481-04:00' AS DateTimeOffset), NULL, N'SYSTEM', CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (3, N'jperez', N'Juan', N'Perez', N'juan.perez@sb.local', N'$2a$11$7mMqUdsiFYY0cA8P5RTFvu.QkUlGK3giHdvJNa3wGbEvnj23Asz9y', 2, 0, CAST(N'2026-06-13T19:13:33.9335003-04:00' AS DateTimeOffset), NULL, N'SYSTEM', CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (4, N'mlopez', N'Maria', N'López', N'maria.lopez@sb.local', N'$2a$11$g7CS6d5JXl.NFO3xv0/MuO5dOkz0k1.qh4kKGLZoQOPZ9gKJm/g5q', 2, 0, CAST(N'2026-06-18T19:13:34.1567196-04:00' AS DateTimeOffset), NULL, N'SYSTEM', CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (5, N'crodriguez', N'Carlos', N'Rodriguez', N'carlos.rodriguez@sb.local', N'$2a$11$vS6u4II.X9fTb8pzkLYsN.Y9YvVib3mKYuDqMrh7JDoFY8anjH5mC', 2, 0, CAST(N'2026-06-23T19:13:34.3800482-04:00' AS DateTimeOffset), NULL, N'SYSTEM', CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
GO
INSERT [Seguridad].[Usuario] ([Id], [NombreUsuario], [Nombres], [Apellidos], [Correo], [HashContrasena], [RolId], [Bloqueado], [FechaCambioContrasena], [UltimoAcceso], [UsuarioRegistra], [FechaRegistra], [UsuarioModifica], [FechaModifica], [Borrado], [Activo]) VALUES (6, N'asantos', N'Antomio', N'Santos', N'ana.santos@sb.local', N'$2a$11$UvqJren/2N0cI5gSlkH36Owd7OevleQl2wg2SKXSSw1c7jNBeBVfu', 2, 0, CAST(N'2026-06-16T19:13:34.6036662-04:00' AS DateTimeOffset), NULL, N'SYSTEM', CAST(N'2026-05-29T19:13:34.7122288-04:00' AS DateTimeOffset), NULL, NULL, 0, 1)
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

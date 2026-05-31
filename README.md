# Sistema de Gestion de Pagos de Empleados

Backend desarrollado en ASP.NET Core Web API para la administracion de empleados, usuarios, permisos, auditoria y generacion de reportes de nomina.

---

# Descripcion General

El Sistema de Gestion de Pagos de Empleados permite administrar de forma centralizada:

* Empleados
* Usuarios
* Roles y permisos
* Catalogos de apoyo
* Reportes de nomina
* Auditoria de operaciones
* Seguridad basada en JWT

La solucion fue desarrollada utilizando una arquitectura multicapa (N-Tier Architecture), aplicando principios SOLID, Repository Pattern, Dependency Injection y buenas practicas de desarrollo empresarial.

---

# Tecnologias Utilizadas

## Backend

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* AutoMapper
* FluentValidation
* BCrypt
* Swagger / OpenAPI
* Serilog
* xUnit

## Arquitectura

* N-Tier Architecture
* Repository Pattern
* Dependency Injection
* Clean Code
* SOLID Principles

---

# Arquitectura de la Solucion

```text
SB.Solution

¢u¢w¢w Domain.Layer
¢x   ¢u¢w¢w SB.Entities
¢x   ¢|¢w¢w SB.Models
¢x
¢u¢w¢w Repository.Layer
¢x   ¢|¢w¢w SB.Repositories
¢x
¢u¢w¢w Service.Layer
¢x   ¢|¢w¢w SB.Services
¢x
¢u¢w¢w Presentation.Layer
¢x   ¢|¢w¢w SB.Restful
¢x
¢|¢w¢w UnitTesting.Layer
    ¢|¢w¢w SB.Tests
```

---

# Responsabilidad de las Capas

## SB.Entities

Contiene las entidades principales de la aplicacion.

Ejemplos:

* Empleado
* Usuario
* Rol
* Permiso
* Auditoria

---

## SB.Models

Contiene:

* DTOs
* Requests
* Responses
* Helpers
* Validaciones
* Objetos de paginacion

---

## SB.Repositories

Implementa:

* Entity Framework Core
* Repositorios
* Configuracion de entidades
* Migraciones
* Seeds
* Interceptores
* Acceso a datos

---

## SB.Services

Contiene toda la logica de negocio.

Servicios principales:

* AuthService
* EmpleadoService
* UsuarioService
* CatalogoService
* ReporteService
* AuditoriaService

---

## SB.Restful

Exposicion de la API REST.

Controladores:

* AuthController
* EmpleadoController
* UsuarioController
* CatalogosController
* ReportesController
* AuditoriaController

---

# Modulos Funcionales

## Seguridad

* Inicio de sesion JWT
* Cambio de contrasena
* Gestion de usuarios
* Roles y permisos
* Bloqueo y desbloqueo de usuarios
* Activacion e inactivacion de usuarios

---

## Recursos Humanos

* Gestion de empleados
* Consulta paginada
* Busqueda avanzada
* Activacion e inactivacion
* Eliminacion logica (Soft Delete)

---

## Catalogos

* Departamentos
* Tipos de empleados
* Modulos del sistema

---

## Reportes

* Reporte semanal de nomina
* Reporte por empleado
* Exportacion de informacion

---

## Auditoria

* Registro automatico de operaciones
* Historial de cambios
* Consulta paginada
* Filtros por usuario
* Filtros por accion
* Filtros por entidad
* Filtros por fechas

---

# Seguridad

## Autenticacion

La API utiliza JWT Bearer Token.

Endpoint de autenticacion:

```http
POST /api/Auth/Login
```

---

## Roles

Actualmente el sistema cuenta con:

```text
Administrador
```

---

## Permisos

| Modulo    | Permisos                                                       |
| --------- | -------------------------------------------------------------- |
| EMPLEADOS | VER, CREAR, EDITAR, ACTIVAR, DESACTIVAR                        |
| USUARIOS  | VER, CREAR, EDITAR, ACTIVAR, DESACTIVAR, BLOQUEAR, DESBLOQUEAR |
| REPORTES  | VER, EXPORTAR                                                  |
| AUDITORIA | VER                                                            |

Los permisos son incluidos como Claims dentro del JWT.

---

# Usuario Demo

```text
Usuario: admin
Password: Admin123!
```

---

# Base de Datos

## Esquema RRHH

```sql
RRHH.Departamento
RRHH.TipoEmpleado
RRHH.Empleado
```

---

## Esquema Seguridad

```sql
Seguridad.Usuario
Seguridad.Rol
Seguridad.Modulo
Seguridad.Permiso
Seguridad.RolPermiso
Seguridad.Auditoria
```

---

# Auditoria

Todas las operaciones de escritura son auditadas automaticamente mediante:

```text
AuditTableInterceptor
```

Se registran:

* Usuario
* Accion
* Entidad
* Identificador
* Direccion IP
* Fecha
* Detalle de cambios

---

# DTOs Principales

## UsuarioDto

Representa la informacion de los usuarios del sistema.

---

## EmpleadoDto

Representa la informacion de los empleados.

---

## LoginRequestDto

Utilizado para autenticacion.

---

## ChangePasswordDto

Utilizado para el cambio de contrasena.

---

# Paginacion

Los modulos siguientes utilizan paginacion:

* Empleados
* Usuarios
* Auditoria

Formato estandar de respuesta:

```json
{
  "items": [],
  "page": 1,
  "pages": 1,
  "take": 10,
  "total": 0
}
```

---

# API Endpoints

## AuthController

| Metodo | Endpoint                 |
| ------ | ------------------------ |
| POST   | /api/Auth/Login          |
| POST   | /api/Auth/ChangePassword |
| GET    | /api/Auth/Profile        |

---

## EmpleadoController

| Metodo | Endpoint                  |
| ------ | ------------------------- |
| GET    | /api/Empleado/GetPaginate |
| GET    | /api/Empleado/{id}        |
| POST   | /api/Empleado             |
| PUT    | /api/Empleado/{id}        |
| PATCH  | /api/Empleado/{id}        |
| DELETE | /api/Empleado/{id}        |

---

## UsuarioController

| Metodo | Endpoint                   |
| ------ | -------------------------- |
| GET    | /api/Usuario/GetPaginate   |
| GET    | /api/Usuario/GetAll        |
| GET    | /api/Usuario/{id}          |
| POST   | /api/Usuario               |
| PUT    | /api/Usuario/{id}          |
| PATCH  | /api/Usuario/{id}/Activate |
| PATCH  | /api/Usuario/{id}/block    |
| DELETE | /api/Usuario/{id}          |

---

## CatalogosController

| Metodo | Endpoint                      |
| ------ | ----------------------------- |
| GET    | /api/Catalogos/departments    |
| GET    | /api/Catalogos/employee-types |
| GET    | /api/Catalogos/modules        |

---

## ReportesController

| Metodo | Endpoint                    |
| ------ | --------------------------- |
| GET    | /api/Reportes/weekly        |
| GET    | /api/Reportes/employee/{id} |

---

## AuditoriaController

| Metodo | Endpoint                   |
| ------ | -------------------------- |
| GET    | /api/Auditoria/GetPaginate |

---

# Instalacion

## Restaurar Dependencias

```bash
dotnet restore
```

---

## Compilar Solucion

```bash
dotnet build
```

---

# Configuracion de Base de Datos

Modificar el archivo:

```text
SB.Restful/appsettings.json
```

Ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SERVIDOR;Database=SBNomina;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---

# Opcion 1 - Crear Base de Datos mediante Migraciones

```seleccionar del proyecto la capa Repository.Layer en el manager console

Eliminar la carpeta:

```text
SB.Repositories/Migrations
```

Crear migracion:

```powershell
Add-Migration InitialCreate
```

Aplicar migracion:

```powershell
Update-Database
```

---

# Opcion 2 - Crear Base de Datos mediante Script SQL

Ubicacion:

```text
SB.Solution\Scripts\EsquemaYData.sql
```

Ejecutar el script completo sobre SQL Server.

El script incluye:

* Esquema de base de datos
* Relaciones
* Catalogos
* Datos iniciales
* Usuario administrador

---

# Ejecucion del Proyecto

## Visual Studio

Seleccionar:

```text
SB.Restful
```

como Startup Project.

Ejecutar:

```text
F5
```

o

```text
Ctrl + F5
```

---

## CLI

```bash
dotnet run
```

---

# Swagger

La documentacion interactiva estara disponible en:

```text
https://localhost:{puerto}/swagger
```

---

# Credenciales

Las credenciales iniciales del sistema se encuentran documentadas en:

```text
CREDENCIALES.md
```

---

# Pruebas

Ejecutar:

```bash
dotnet test
```
---

# Caracteristicas Implementadas

* JWT Authentication
* Roles y Permisos
* Gestion de Empleados
* Gestion de Usuarios
* Auditoria Automatica
* Catalogos
* Reportes
* Soft Delete
* Paginacion
* Logging
* Validaciones
* Swagger
* Entity Framework Core
* SQL Server
* Arquitectura Multicapa
* Repository Pattern
* Dependency Injection

---

# Licencia

Proyecto desarrollado con fines academicos y de demostracion de buenas practicas de desarrollo en .NET.


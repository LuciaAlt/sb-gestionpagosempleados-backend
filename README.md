# Sistema de Gesti車n de Pagos de Empleados

Backend desarrollado en ASP.NET Core Web API para la administraci車n de empleados, usuarios, permisos, auditor赤a y generaci車n de reportes de n車mina.

---

# Descripci車n General

El Sistema de Gesti車n de Pagos de Empleados permite administrar de forma centralizada:

* Empleados
* Usuarios
* Roles y permisos
* Cat芍logos de apoyo
* Reportes de n車mina
* Auditor赤a de operaciones
* Seguridad basada en JWT

La soluci車n fue desarrollada utilizando una arquitectura multicapa (N-Tier Architecture), aplicando principios SOLID, Repository Pattern, Dependency Injection y buenas pr芍cticas de desarrollo empresarial.

---

# Tecnolog赤as Utilizadas

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

# Arquitectura de la Soluci車n

```text
SB.Solution

念岸岸 Domain.Layer
岫   念岸岸 SB.Entities
岫   弩岸岸 SB.Models
岫
念岸岸 Repository.Layer
岫   弩岸岸 SB.Repositories
岫
念岸岸 Service.Layer
岫   弩岸岸 SB.Services
岫
念岸岸 Presentation.Layer
岫   弩岸岸 SB.Restful
岫
弩岸岸 UnitTesting.Layer
    弩岸岸 SB.Tests
```

---

# Responsabilidad de las Capas

## SB.Entities

Contiene las entidades principales de la aplicaci車n.

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
* Objetos de paginaci車n

---

## SB.Repositories

Implementa:

* Entity Framework Core
* Repositorios
* Configuraci車n de entidades
* Migraciones
* Seeds
* Interceptores
* Acceso a datos

---

## SB.Services

Contiene toda la l車gica de negocio.

Servicios principales:

* AuthService
* EmpleadoService
* UsuarioService
* CatalogoService
* ReporteService
* AuditoriaService

---

## SB.Restful

Exposici車n de la API REST.

Controladores:

* AuthController
* EmpleadoController
* UsuarioController
* CatalogosController
* ReportesController
* AuditoriaController

---

# M車dulos Funcionales

## Seguridad

* Inicio de sesi車n JWT
* Cambio de contrase?a
* Gesti車n de usuarios
* Roles y permisos
* Bloqueo y desbloqueo de usuarios
* Activaci車n e inactivaci車n de usuarios

---

## Recursos Humanos

* Gesti車n de empleados
* Consulta paginada
* B迆squeda avanzada
* Activaci車n e inactivaci車n
* Eliminaci車n l車gica (Soft Delete)

---

## Cat芍logos

* Departamentos
* Tipos de empleados
* M車dulos del sistema

---

## Reportes

* Reporte semanal de n車mina
* Reporte por empleado
* Exportaci車n de informaci車n

---

## Auditor赤a

* Registro autom芍tico de operaciones
* Historial de cambios
* Consulta paginada
* Filtros por usuario
* Filtros por acci車n
* Filtros por entidad
* Filtros por fechas

---

# Seguridad

## Autenticaci車n

La API utiliza JWT Bearer Token.

Endpoint de autenticaci車n:

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

| M車dulo    | Permisos                      |
| --------- | ----------------------------- |
| EMPLEADOS | VER, CREAR, EDITAR, ACTIVARORDESACTIVAR |
| USUARIOS  | VER, CREAR, EDITAR, ACTIVARORDESACTIVAR ,BLOQUEAORDESBLOQUEA|
| REPORTES  | VER, EXPORTAR                 |
| AUDITORIA | VER                           |

Los permisos son incluidos como Claims dentro del JWT.

---
## ?懁 Usuario Demo

```text
Usuario: admin
Password: Admin123!
```

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

# Auditor赤a

Todas las operaciones de escritura son auditadas autom芍ticamente mediante:

```text
AuditTableInterceptor
```

Se registran:

* Usuario
* Acci車n
* Entidad
* Identificador
* Direcci車n IP
* Fecha
* Detalle de cambios

---

# DTOs Principales

## UsuarioDto

Representa la informaci車n de los usuarios del sistema.

---

## EmpleadoDto

Representa la informaci車n de los empleados.

---

## LoginRequestDto

Utilizado para autenticaci車n.

---

## ChangePasswordDto

Utilizado para el cambio de contrase?a.

---

# Paginaci車n

Los m車dulos siguientes utilizan paginaci車n:

* Empleados
* Usuarios
* Auditor赤a

Formato est芍ndar de respuesta:

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

| M谷todo | Endpoint                 |
| ------ | ------------------------ |
| POST   | /api/Auth/Login          |
| POST   | /api/Auth/ChangePassword |
| GET    | /api/Auth/Profile        |

---

## EmpleadoController

| M谷todo | Endpoint                  |
| ------ | ------------------------- |
| GET    | /api/Empleado/GetPaginate |
| GET    | /api/Empleado/{id}        |
| POST   | /api/Empleado             |
| PUT    | /api/Empleado/{id}        |
| PATCH  | /api/Empleado/{id}        |
| DELETE | /api/Empleado/{id}        |

---

## UsuarioController

| M谷todo | Endpoint                 |
| ------ | ------------------------ |
| GET    | /api/Usuario/GetPaginate |
| GET    | /api/Usuario/GetAll      |
| GET    | /api/Usuario/{id}        |
| POST   | /api/Usuario             |
| PUT    | /api/Usuario/{id}        |
| PATCH  | /api/Usuario/{id}/Activate|
| PATCH  | /api/Usuario/{id}/block  |
| DELETE | /api/Usuario/{id}        |

---

## CatalogosController

| M谷todo | Endpoint                      |
| ------ | ----------------------------- |
| GET    | /api/Catalogos/departments    |
| GET    | /api/Catalogos/employee-types |
| GET    | /api/Catalogos/modules        |

---

## ReportesController

| M谷todo | Endpoint                    |
| ------ | --------------------------- |
| GET    | /api/Reportes/weekly        |
| GET    | /api/Reportes/employee/{id} |

---

## AuditoriaController

| M谷todo | Endpoint                   |
| ------ | -------------------------- |
| GET    | /api/Auditoria/GetPaginate |

---

# Instalaci車n

## Restaurar Dependencias

```bash
dotnet restore
```

---

## Compilar Soluci車n

```bash
dotnet build
```

---

# Configuraci車n de Base de Datos

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

# Opci車n 1 - Crear Base de Datos mediante Migraciones

Eliminar la carpeta:

```text
SB.Repositories/Migrations
```

Crear migraci車n:

```powershell
Add-Migration InitialCreate
```

Aplicar migraci車n:

```powershell
Update-Database
```

---

# Opci車n 2 - Crear Base de Datos mediante Script SQL

Ubicaci車n:

```text
SB.Solution\Scripts\EsquemaYData.sql
```

Ejecutar el script completo sobre SQL Server.

El script incluye:

* Esquema de base de datos
* Relaciones
* Cat芍logos
* Datos iniciales
* Usuario administrador

---

# Ejecuci車n del Proyecto

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

La documentaci車n interactiva estar芍 disponible en:

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

# Caracter赤sticas Implementadas

* JWT Authentication
* Roles y Permisos
* Gesti車n de Empleados
* Gesti車n de Usuarios
* Auditor赤a Autom芍tica
* Cat芍logos
* Reportes
* Soft Delete
* Paginaci車n
* Logging
* Validaciones
* Swagger
* Entity Framework Core
* SQL Server
* Arquitectura Multicapa
* Repository Pattern
* Dependency Injection

## ?? Licencia

Proyecto desarrollado con fines acad矇micos y de demostraci籀n de buenas pr獺cticas de desarrollo en .NET.
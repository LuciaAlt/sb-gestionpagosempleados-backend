#  SB - Superintendencia de Bancos System

Sistema de Gestión de Nómina y Recursos Humanos desarrollado para la administración de empleados, usuarios, permisos y cálculo de pagos semanales.

##  Tecnologías

### Backend

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- FluentValidation
- AutoMapper
- Serilog
- xUnit

### Arquitectura

- N-Tier Architecture
- Clean Architecture
- Repository Pattern
- Strategy Pattern
- Dependency Injection
- SOLID Principles

---

##  Características

### Seguridad

- Autenticación JWT
- Roles y permisos
- Password Hashing con BCrypt
- Rate Limiting
- CORS
- Auditoría completa

### Gestión de Empleados

- Registro de empleados
- Actualización de información
- Eliminación lógica (Soft Delete)
- Consulta paginada
- Búsqueda avanzada

### Tipos de Empleados

| Tipo | Descripción |
|--------|-------------|
| Asalariado | Pago semanal fijo |
| Por Horas | Horas normales + horas extras |
| Por Comisión | Ventas × comisión |
| Asalariado por Comisión | Salario base + comisión + bonificación |

### Reportes

- Reporte semanal de nómina
- Historial de auditoría
- Consulta paginada de registros

---

##  Arquitectura de la Solución

```text
SB.Solution
│
├── Domain.Layer
│   ├── SB.Entities
│   └── SB.Models
│
├── Repository.Layer
│   └── SB.Repositories
│
├── Service.Layer
│   └── SB.Services
│
├── Presentation.Layer
│   └── SB.Restful
│
├── Shared.Layer
│   └── SB.Helpers
│
└── UnitTesting.Layer
    └── SB.Tests
```

---

##  Cálculo de Nómina

### Empleado Asalariado

```text
Pago = SalarioSemanal
```

### Empleado por Horas

```text
Pago = HorasNormales + HorasExtras × 1.5
```

### Empleado por Comisión

```text
Pago = VentasBrutas × TarifaComision
```

### Empleado Asalariado por Comisión

```text
Pago = SalarioBase + Comisión + (SalarioBase × 10%)
```

---

##  Permisos

| Módulo | Permisos |
|---------|----------|
| EMPLEADOS | VER, CREAR, EDITAR, INACTIVAR |
| REPORTES | VER, EXPORTAR |
| USUARIOS | VER, CREAR |
| AUDITORIA | VER |

Los permisos se incluyen como Claims dentro del JWT.

---

##  API Endpoints

### Autenticación

| Método | Endpoint |
|---------|-----------|
| POST | `/api/auth/login` |

### Empleados

| Método | Endpoint |
|---------|-----------|
| GET | `/api/Empleados/GetPaginate` |
| GET | `/api/Empleados/{id}` |
| POST | `/api/Empleados` |
| PUT | `/api/Empleados/{id}` |
| DELETE | `/api/Empleados/{id}` |

### Usuarios

| Método | Endpoint |
|---------|-----------|
| GET | `/api/Users/GetPaginate` |
| GET | `/api/Users/{id}` |
| POST | `/api/Users` |
| PUT | `/api/Users/{id}` |
| DELETE | `/api/Users/{id}` |

### Catálogos

| Método | Endpoint |
|---------|-----------|
| GET | `/api/Catalogos/departments` |
| GET | `/api/Catalogos/employee-types` |
| GET | `/api/Catalogos/modules` |

### Reportes

| Método | Endpoint |
|---------|-----------|
| GET | `/api/Reportes/weekly` |

### Auditoría

| Método | Endpoint |
|---------|-----------|
| GET | `/api/AuditLogs/GetPaginate` |

---

##  Base de Datos

### Esquema RRHH

```sql
RRHH.Departamento
RRHH.TipoEmpleado
RRHH.Empleado
```

### Esquema Seguridad

```sql
Seguridad.Usuario
Seguridad.Rol
Seguridad.Modulo
Seguridad.Permiso
Seguridad.RolPermiso
Seguridad.Auditoria
```

---

##  Instalación

### Restaurar paquetes

```bash
dotnet restore
```

### Crear migraciones

```bash
dotnet ef migrations add InitialCreate
```

### Aplicar migraciones

```bash
dotnet ef database update
```

### Ejecutar API

```bash
dotnet run
```

---

##  Pruebas

```bash
dotnet test
```

---

##  Usuario Demo

```text
Usuario: admin
Password: Admin123!
```

---

##  Licencia

Proyecto desarrollado con fines de prueba técnica y de demostración de buenas prácticas de desarrollo en .NET.

#  Credenciales de Usuarios Precargados

Estas 6 cuentas se siembran automáticamente al arrancar la API por primera vez.

##  Administradores (rol `ADMIN`)

Acceso completo: ver, crear, editar, inactivar empleados, gestionar usuarios, ver bitácora, exportar reportes.

| # | Username | Contraseña | Email | Rol |
|---|---|---|---|---|
| 1 | `admin` | `Admin123!` | admin@sb.local | ADMIN |
| 2 | `supervisor` | `Super123!` | supervisor@sb.local | ADMIN |

## Usuarios normales (rol `USUARIO`)

Solo lectura: ver empleados, ver reportes, exportar reportes. **No pueden** crear ni editar empleados ni gestionar usuarios.

| # | Username | Contraseña | Email | Rol |
|---|---|---|---|---|
| 3 | `jperez` | `Juan123!` | juan.perez@sb.local | USUARIO |
| 4 | `mlopez` | `Maria123!` | maria.lopez@sb.local | USUARIO |
| 5 | `crodriguez` | `Carlos123!` | carlos.rodriguez@sb.local | USUARIO |
| 6 | `asantos` | `Ana123!` | ana.santos@sb.local | USUARIO |

---

##  Permisos por rol

### Rol ADMIN (Id=1) — los 9 permisos
- EMPLEADOS_VER, EMPLEADOS_CREAR, EMPLEADOS_EDITAR, EMPLEADOS_INACTIVAR
- REPORTES_VER, REPORTES_EXPORTAR
- USUARIOS_VER, USUARIOS_CREAR, AUDITORIA_VER

### Rol USUARIO (Id=2) — 3 permisos (solo lectura)
- EMPLEADOS_VER
- REPORTES_VER
- REPORTES_EXPORTAR

---

##  Cómo probarlo

### En Swagger

1. Ir a `http://localhost:5080`
2. `POST /api/auth/login`:
   ```json
   { "username": "admin", "password": "Admin123!" }
   ```
3. Copiar el `token` de la respuesta.
4. Click en **Authorize ** → `Bearer <token>` → **Authorize**.
5. Probar:
   - `GET /api/Empleados/GetPaginate?Page=1&Take=10` → ve los 12 empleados sembrados
   - `GET /api/Reports/weekly` → reporte con cálculo de pago
   - `GET /api/AuditLogs/GetPaginate?Page=1&Take=10` → bitácora de cambios

### Para probar el sistema de permisos

1. Login como `jperez / Juan123!` (rol USUARIO)
2. Intenta `POST /api/Empleados` → debe devolver **403 Forbidden** ✓
3. `GET /api/Empleados/GetPaginate` → debe funcionar ✓

---

##  ¿Por qué las contraseñas se siembran en runtime?

BCrypt es un algoritmo de hash **no-determinístico**: cada vez que se hashea la misma contraseña, produce un hash diferente. Esto es una propiedad de seguridad deseable (protege contra rainbow tables).

Pero rompe `HasData` de EF Core, que requiere valores deterministas para detectar cambios entre migraciones. Por eso:
- **Catálogos** (departments, roles, permissions, etc.) → `HasData` (deterministas)
- **Usuarios con contraseña** → runtime seeder (`DataSeeder.cs`)

Es la práctica estándar en proyectos profesionales.

---

##  Importante para el frontend

Cuando construyamos el frontend, usaremos estas credenciales para:
- **Pantalla de login**: validar con `admin / Admin123!`
- **Mostrar/ocultar botones**: el JWT incluye los permisos como claims `permission`, el frontend los lee y decide qué mostrar
- **Probar control de acceso**: loguearse como `jperez` para verificar que no aparece el botón "Registrar empleado"

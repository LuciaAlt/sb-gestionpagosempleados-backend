namespace SB.Models.Helpers;

public static class Constants
{
    public static class Schemas
    {
        public const string RRHH = "RRHH";
        public const string Seguridad = "Seguridad";
    }

    public static class Roles
    {
        public const string Admin = "ADMIN";
        public const string Usuario = "USUARIO";
    }

    public static class Validation
    {
        public const decimal HorasMaxSemana = 168m;
        public const decimal TarifaComisionMin = 0m;
        public const decimal TarifaComisionMax = 1m;
    }

    public static class Payment
    {
        public const decimal HorasRegulares = 40m;
        public const decimal FactorHorasExtra = 1.5m;
        public const decimal BonificacionAsalariadoComision = 0.10m;
    }

    public static class AuditActions
    {
        public const string Login       = "LOGIN";
        public const string LoginFail   = "LOGIN_FAIL";
        public const string Logout      = "LOGOUT";
        public const string Create      = "CREATE";
        public const string Update      = "UPDATE";
        public const string Delete      = "DELETE";
        public const string SoftDelete  = "SOFT_DELETE";
    }

    public static class System
    {
        /// <summary>Identidad usada cuando no hay usuario autenticado (seeds, jobs).</summary>
        public const string SystemUser = "SYSTEM";
        public const string Anonimo = "ANONIMO";
    }
}

namespace SB.Helpers.Exceptions;

public class AppException : Exception
{
    public int StatusCode { get; }
    public AppException(string message, int statusCode = 400) : base(message) => StatusCode = statusCode;
}

public class NotFoundException : AppException
{
    public NotFoundException(string entity, object key)
        : base($"{entity} con identificador '{key}' no fue encontrado.", 404) { }
}

public class ValidationException : AppException
{
    public IDictionary<string, string[]> Errors { get; }
    public ValidationException(
        string message,
        IDictionary<string, string[]> errors)
        : base(message, 422)
    {
        Errors = errors;
    }
}

public class UnauthorizedException : AppException
{
    public UnauthorizedException(string message = "Credenciales inválidas.") : base(message, 401) { }
}

public class ForbiddenException : AppException
{
    public ForbiddenException(string permiso) : base($"No tiene el permiso requerido: {permiso}.", 403) { }
}

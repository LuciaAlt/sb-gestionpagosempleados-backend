using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SB.Helpers.Exceptions;
using System.Net;
using System.Text.Json;

namespace SB.Helpers.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext ctx)
    {
        try
        {
            await _next(ctx);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning("Validación: {@Errors}", ex.Errors);

            await WriteAsync(ctx, ex.StatusCode, new
            {
                message = ex.Message,
                errors = ex.Errors
            });
        }
        catch (AppException ex)
        {
            _logger.LogWarning(ex, "AppException: {Message}", ex.Message);

            await WriteAsync(ctx, ex.StatusCode, new
            {
                message = ex.Message
            });
        }
        catch (DbUpdateException ex) when (
            ex.InnerException?.Message.Contains("IX_Empleado_NumeroSeguroSocial") == true)
        {
            _logger.LogWarning(ex, "Número de seguro social duplicado");

            await WriteAsync(ctx, (int)HttpStatusCode.Conflict, new
            {
                message = "Ya existe un empleado con ese número de seguro social."
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error no controlado en {Path}", ctx.Request.Path);

            await WriteAsync(ctx, (int)HttpStatusCode.InternalServerError, new
            {
                message = "Ocurrió un error inesperado. Por favor intente de nuevo."
            });
        }
    }

    private static Task WriteAsync(HttpContext ctx, int status, object payload)
    {
        ctx.Response.ContentType = "application/json";
        ctx.Response.StatusCode = status;
        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return ctx.Response.WriteAsync(json);
    }
}

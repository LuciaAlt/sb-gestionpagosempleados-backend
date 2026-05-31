using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SB.Helpers.Security;
using SB.Models.Contracts;
using SB.Repositories.Context;
using SB.Repositories.Implementation;
using SB.Repositories.Interceptors;
using SB.Repositories.Validators;
using SB.Services.Implementation;
using SB.Services.Interface;
using SB.Services.Strategies;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SB.Services;

/// <summary>
/// Extensiones centralizadas de inyección de dependencias.
/// Organización por capas: infraestructura, aplicación y presentación.
/// </summary>
public static class DependencyInjection
{
    #region Infrastructure (DbContext)

    public static void ConfigureDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AuditableInterceptor>();

        services.AddDbContext<SBDbContext>((sp, options) =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("SBContext"),
                sql =>
                {
                    sql.MigrationsAssembly(typeof(SBDbContext).Assembly.FullName);
                });

            options.AddInterceptors(
                sp.GetRequiredService<AuditableInterceptor>());
        });
    }

    #endregion

    #region Repositories

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuditLogRepository, AuditLogRepository>();
    }

    #endregion

    #region Application Services

    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        // Strategies
        services.AddScoped<IPaymentStrategy, SalariedPaymentStrategy>();
        services.AddScoped<IPaymentStrategy, HourlyPaymentStrategy>();
        services.AddScoped<IPaymentStrategy, CommissionPaymentStrategy>();
        services.AddScoped<IPaymentStrategy, BasePlusCommissionPaymentStrategy>();
        services.AddScoped<IPaymentStrategyResolver, PaymentStrategyResolver>();

        // Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmpleadoService, EmpleadoService>();
        services.AddScoped<IUsuariosService, UsuarioService>();
        services.AddScoped<ICatalogosService, CatalogService>();
        services.AddScoped<IReportesService, ReportesService>();
        services.AddScoped<IAuditoriaService, AuditoriaService>();

        // Security
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    }

    #endregion

    #region Validation

    public static void ConfigureValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<EmpleadoDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<UsuarioDtoValidator>();
    }

    #endregion

    #region AutoMapper

    public static void ConfigureMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    #endregion

    #region Controllers

    public static void ConfigureControllers(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler =
                    ReferenceHandler.IgnoreCycles;

                options.JsonSerializerOptions.Converters.Add(
                    new JsonStringEnumConverter());
            });
    }

    #endregion

    #region CORS (seguro por ambiente)
    public static void ConfigureCorsPolicy(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        var allowedOrigins =
            configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

        services.AddCors(options =>
        {
            options.AddPolicy("cors", policy =>
            {
                policy.WithOrigins(allowedOrigins)
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
    }
    public static void ConfigureCorsPolicy1(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var allowedOrigins =
            configuration.GetSection("Cors:Origins").Get<string[]>() ?? Array.Empty<string>();

        services.AddCors(options =>
        {
            options.AddPolicy("cors", policy =>
            {
                if (allowedOrigins.Length == 0)
                {
                    // DEV fallback
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                }
                else
                {
                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                }
            });
        });
    }

    #endregion

    #region Swagger

    public static void ConfigureSwagger(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            var assembly = Assembly.GetEntryAssembly()
                ?? Assembly.GetExecutingAssembly();

            ConfigureSwaggerDoc(options, assembly);
            ConfigureSecurity(options);
            IncludeXmlComments(options, assembly);
            options.CustomSchemaIds(type => type.FullName);
        });
    }

    private static void ConfigureSwaggerDoc(
        SwaggerGenOptions options,
        Assembly assembly)
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = assembly.GetName().Name ?? "SB API",
            Version = "v1",
            Description = "API de comunicación con SB.",
            Contact = new OpenApiContact
            {
                Name = "Superintendencia de Bancos",
                Email = "contacto@sb.gob.do",
                Url = new Uri("https://www.sb.gob.do/")
            }
        });
    }

    private static void ConfigureSecurity(SwaggerGenOptions options)
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using Bearer."
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    }

    private static void IncludeXmlComments(
        SwaggerGenOptions options,
        Assembly assembly)
    {
        var files = new[]
        {
            $"{assembly.GetName().Name}.xml",
            $"{Assembly.GetExecutingAssembly().GetName().Name}.xml",
            "SB.Models.xml"
        };

        foreach (var file in files)
        {
            var path = Path.Combine(AppContext.BaseDirectory, file);

            if (File.Exists(path))
            {
                options.IncludeXmlComments(path);
            }
        }
    }

    #endregion
}
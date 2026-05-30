using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SB.Helpers.Security;
using SB.Models.Contracts;
using SB.Repositories.Context;
using SB.Repositories.Implementation;
using SB.Repositories.Interceptors;
using SB.Repositories.Validators;

namespace SB.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
    {
        // Interceptor de auditoría (scoped: lee el usuario actual de cada request)
        services.AddScoped<AuditableInterceptor>();

        services.AddDbContext<SBDbContext>((sp, opt) =>
        {
            opt.UseSqlServer(config.GetConnectionString("Default"),
                sql => sql.MigrationsAssembly(typeof(SBDbContext).Assembly.FullName));
            opt.AddInterceptors(sp.GetRequiredService<AuditableInterceptor>());
        });

        // Repositorios
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuditLogRepository, AuditLogRepository>();

        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<EmployeeDtoValidator>();

        // JWT options
        services.Configure<JwtOptions>(config.GetSection(JwtOptions.SectionName));

        return services;
    }
}

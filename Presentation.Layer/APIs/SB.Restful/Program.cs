using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SB.Helpers.CurrentUser;
using SB.Helpers.Middlewares;
using SB.Helpers.Security;
using SB.Models.Contracts;
using SB.Repositories.Context;
using SB.Repositories.Seed;
using SB.Services;

var builder = WebApplication.CreateBuilder(args);

#region SERILOG
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/sb-.log", (Serilog.Events.LogEventLevel)RollingInterval.Day, retainedFileCountLimit: 14)
    .CreateLogger();

builder.Host.UseSerilog();
#endregion

#region BASE SERVICES
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
#endregion

#region Infrastructure (DbContext)
builder.Services.ConfigureDbContext(builder.Configuration);

#endregion

#region EXTENSION LAYER 

builder.Services.ConfigureControllers();
builder.Services.ConfigureCorsPolicy(builder.Configuration);
builder.Services.ConfigureMapping();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureValidation();
builder.Services.ConfigureSwagger(builder.Configuration);

#endregion

#region JWT

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection(JwtOptions.SectionName));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwt = builder.Configuration
            .GetSection(JwtOptions.SectionName)
            .Get<JwtOptions>();

        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwt.Issuer,

            ValidateAudience = true,
            ValidAudience = jwt.Audience,

            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt.SecretKey)),

            ClockSkew = TimeSpan.FromSeconds(30)
        };
    });

builder.Services.AddAuthorization();

#endregion

#region  RATE LIMITER
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = 429;

    options.AddFixedWindowLimiter("default", limiter =>
    {
        limiter.PermitLimit = 100;
        limiter.Window = TimeSpan.FromMinutes(1);
        limiter.QueueLimit = 0;
    });
});
#endregion

var app = builder.Build();

#region SEED DATABASE
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<SBDbContext>();
        var hasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        await DataSeeder.InitializeAsync(db, hasher);

        Log.Information("Database initialized successfully.");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Database initialization error.");
    }
}
#endregion

#region PIPELINE

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseAuthentication();
app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers()
   .RequireRateLimiting("default");

app.Run();

public partial class Program { }
#endregion
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using bingo_api;
using bingo_api.Models.Entities;
using bingo_api.Models.Entities.Services.Achievement;
using bingo_api.Models.Services.Auth;
using bingo_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Services.AddScoped<ILevelService, LevelService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuickplayService, QuickplayService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAchievementService, AchievementService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "CustomToken";
        options.DefaultChallengeScheme = "CustomToken";
    })
    .AddScheme<AuthenticationSchemeOptions, PostgresTokenAuthentication>("CustomToken", _ => { });

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var tlsConf = builder.Configuration.GetSection("TLS");
    var httpPort = tlsConf.GetValue<int>("Http_Port");
    var httpsPort = tlsConf.GetValue<int>("Https_Port");
    var certPath = tlsConf.GetValue<string>("Cert_Path");
    var certPassword = tlsConf.GetValue<string>("Cert_Password");

    serverOptions.ListenAnyIP(httpPort);
    serverOptions.ListenAnyIP(httpsPort,
        listenOptions => { listenOptions.UseHttps(new X509Certificate2(certPath, certPassword)); });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

using var serviceScope = app.Services.CreateScope();
var dbContext = serviceScope.ServiceProvider.GetRequiredService<PostgresContext>();
dbContext.Database.Migrate();

app.Run();
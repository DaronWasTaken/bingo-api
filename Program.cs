using System.Security.Claims;
using System.Text;
using System.Text.Json;
using bingo_api.Models.Entities;
using bingo_api.Models.Entities.Services.Achievement;
using bingo_api.Models.Services.Auth;
using bingo_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });

Console.WriteLine("CONNECTION STRING: {0}", builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var keyString = builder.Configuration.GetValue<string>("Jwt:Key");
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        RequireExpirationTime = true,
        IssuerSigningKey = key
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            if (context.Principal?.Identity is not ClaimsIdentity claims) return Task.CompletedTask;
            var tokenType = claims.FindFirst("token_type");
            if (tokenType is not { Value: "refresh_token" }) return Task.CompletedTask;
            context.Fail("Unauthorized: Token is a refresh token");
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddScoped<ILevelService, LevelService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuickplayService, QuickplayService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAchievementService, AchievementService>();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

// app.UseHttpsRedirection();
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
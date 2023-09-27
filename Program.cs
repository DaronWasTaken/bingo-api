using bingo_api.EfModels;
using bingo_api.Services;
using bingo_api.Services.Level;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BingoDevContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ILevelService, LevelService>();
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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

app.MapPost("/createLevel", (BingoDevContext db) =>
{
    var newLevel = new Level
    {
        LevelNumber = 2,
        RequiredPoints = 1000
    };

    db.Levels.Add(newLevel);
    db.SaveChanges();
});

app.MapDelete("/removeLevel/{id:int}",(BingoDevContext db, int id) =>
{
    db.Levels.Remove(db.Levels.Find(id));
    db.SaveChanges();
});

app.Run();
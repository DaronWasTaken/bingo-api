using bingo_api.EfModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BingoDevContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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
        Levelnumber = 2,
        Requiredpoints = 1000
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
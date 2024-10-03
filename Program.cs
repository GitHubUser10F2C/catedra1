using catedra1.src.Data;
using catedra1.src.Interfaces;
using catedra1.Src.Data;
using catedra1.Src.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data source=database.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services =  scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    DataSeeder.Initialize(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
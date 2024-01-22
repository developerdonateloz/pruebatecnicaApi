using ApiPruebaTecnica.DbModel.Context;
using ApiPruebaTecnica.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseOracle(builder.Configuration["ConnectionStrings:oracle_db"]);
});

builder.Services.AddTransient<IMatriculaService, MatriculaService>();
builder.Services.AddTransient<IDetalleMatriculaService, DetalleMatriculaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

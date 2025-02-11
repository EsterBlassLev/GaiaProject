using Calculator.Core.Interfaces;
using Calculator.Data.CalculationDbContext;
using Calculator.Data.Interfaces;
using Calculator.Data.Repositories;
using Calculator.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DB Context
builder.Services.AddDbContext<CalcDbContext>(options =>
    options.UseSqlServer("Server=DESKTOP-RKU2RFR;Database=CALCULATOR;Trusted_Connection=True;MultipleActiveResultSets=true")
);

// Add Services
builder.Services.AddScoped<IOperationService, OperationService>();
builder.Services.AddScoped<IOperationRepository, OperationRepository>();
builder.Services.AddScoped<IOperation, Operations>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

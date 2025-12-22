using CatalogService.API.Data;
using CatalogService.API.Data.Seed;
using CatalogService.API.Middleware;
using CatalogService.API.Models;
using CatalogService.API.Repositories;
using CatalogService.API.Repositories.Interfaces;
using CatalogService.API.Services;
using CatalogService.API.Services.Interfaces;
using CatalogService.API.Validators;

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text;
//using CatalogService.API.Validators;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseSqlServer(
           builder.Configuration.GetConnectionString("connString")
    )
);
builder.Services.AddValidatorsFromAssemblyContaining<ModelCreateRequestValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IModelService, ModelService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();

    var baseModelId = context.Models
        .Where(m => m.IsBaseConcept)
        .Select(m => m.Id)
        .First();

    await CatalogSeeder.SeedAsync(context);
    await LayerGroupSeeder.SeedAsync(context, baseModelId);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

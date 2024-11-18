using Clothes.Api;
using Clothes.Api.Models;
using Clothes.Api.Models.Validators;
using Clothes.Api.Services;
using FluentValidation;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureOpenTelemetry();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IItemRepository, ItemRepository>();
builder.Services.AddSingleton<IItemProvider, ItemProvider>();
builder.Services.AddTransient<IValidator<FilterResource>, FilterResourceValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger( options =>{
            options.RouteTemplate = "openapi/{documentName}.json";
            });
    app.MapScalarApiReference( Options =>{
            Options.WithTheme(ScalarTheme.Mars);
            });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

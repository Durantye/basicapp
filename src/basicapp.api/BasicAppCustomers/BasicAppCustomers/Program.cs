using System;
using BasicAppCustomers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// load configuration:
// connection string comes from appsettings
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{environment}.json", optional: true);

var connectionString = builder.Configuration.GetConnectionString("default");
Console.WriteLine(connectionString);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add db context
builder.Services.AddScoped<CustomersDbContext>(provider =>
{
    var options = new DbContextOptionsBuilder<CustomersDbContext>()
        .UseNpgsql(connectionString);
    return new CustomersDbContext(options.Options);
});

builder.Services.AddScoped<CustomersDatabaseService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allowed",
        builder =>
        {
            //builder.WithOrigins("https://localhost:3000", "http://localhost:3000");
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithExposedHeaders("x-custom-header")
                .WithExposedHeaders("Acccess-Control-Allow-Origin");
            //builder.AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allowed");

app.UseAuthorization();

app.MapControllers();

app.Run();
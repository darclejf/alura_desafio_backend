using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.WebAPI.Extensions;
using AluraChallenge.Adopet.WebAPI.Setup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.AddGlobalErrorHandler();

app.Run();


void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddDbContext<AdopetDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    //services.AddDbContext<AdopetDbContext>(opt => opt.UseSqlite("DataSource=adopet.db;Cache=Shared");

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.RegisterServices();
}
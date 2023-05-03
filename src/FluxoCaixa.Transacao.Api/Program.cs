using FluxoCaixa.Api.Data.Repository;
using FluxoCaixa.Api.Filters;
using FluxoCaixa.Api.Services;
using FluxoCaixa.Core;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

GetDataBaseConfig.RegisterServices(builder.Services);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IService, Service>();

builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
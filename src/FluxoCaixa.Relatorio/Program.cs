using FluxoCaixa.Core;
using FluxoCaixa.Data.Repository;
using FluxoCaixa.Relatorio.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

GetDataBaseConfig.RegisterServices(builder.Services);

builder.Services.AddTransient<IService, Service>();

builder.Services.AddTransient<IRepository, Repository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
﻿using Microsoft.Extensions.Configuration;
using ProductPlayground.Persistence;
using ProductPlayground.Application;
using ProductPlayground.Infrastructure;
using ProductPlayground.Mapper;
using ProductPlayground.Application.Exceptions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional:false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

var jwtConfiguration = builder.Configuration.GetSection("JWT");
var swaggerConfiguration = builder.Configuration.GetSection("SwaggerConfiguration");
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { 
        Title = swaggerConfiguration.GetValue<string>("Title"), 
        Version = swaggerConfiguration.GetValue<string>("Version"), 
        Description = swaggerConfiguration.GetValue<string>("Description")
    });
    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = jwtConfiguration.GetValue<string>("Name"),
        Type = SecuritySchemeType.ApiKey,
        Scheme = jwtConfiguration.GetValue<string>("Scheme"),
        BearerFormat = jwtConfiguration.GetValue<string>("BearerFormat"),
        In = ParameterLocation.Header,
        // Description = ""
    });
    s.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = jwtConfiguration.GetValue<string>("Scheme"),
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureExceptionHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();


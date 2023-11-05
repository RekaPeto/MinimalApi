using test.EndpointDefinitions;
using test.Models;
using test.Repositories;
using test.SecretSauce;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpointDefinitions();

app.Run();


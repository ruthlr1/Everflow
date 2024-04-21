using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.Events;
using MediatR;
using Everflow.EventPlanner.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Everflow.EventPlanner.API.Register;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

RegisterContext.Register(builder);
RegisterServices.Register(builder.Services);
RegisterToken.Register(builder.Services);


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

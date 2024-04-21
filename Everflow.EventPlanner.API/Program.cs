using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.Events;
using MediatR;
using Everflow.EventPlanner.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EverflowContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRequestHandler<GetMyEventsLookupQuery, IList<EventDetailLookupModel>>, GetMyEventsLookupQueryHandler>();
builder.Services.AddScoped(typeof(IEventService), typeof(EventService));

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

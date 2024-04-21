using Everflow.EventPlanner.Persistence.Database;
using Everflow.EventPlanner.UI;
using Everflow.EventPlanner.UI.ServerSide;
using Everflow.EventPlanner.UI.ServerSide.Components;
using Everflow.EventPlanner.UI.ServerSide.Register;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(o =>
    {
        o.DetailedErrors = true;
    }); ;

builder.Services.AddMudServices();

RegisterContext.Register(builder);
RegisterServices.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

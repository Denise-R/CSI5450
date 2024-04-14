using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using BalzorMongoDB.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using Radzen.Blazor.Rendering;
using System.Transactions;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAgent, AgentService>();
builder.Services.AddScoped<IAppliances, AppliancesService>();
builder.Services.AddScoped<IAppliancesOwned, AppliancesOwnedService>();
builder.Services.AddScoped<ICompany, CompanyService>();
builder.Services.AddScoped<ICounty, CountyService>();
builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IHome, HomeService>();
builder.Services.AddScoped<IHomeOwner, HomeOwnerService>();
builder.Services.AddScoped<IListing, ListingService>();
builder.Services.AddScoped<ILocation, LocationService>();
builder.Services.AddScoped<ISalesMade, SalesMadeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

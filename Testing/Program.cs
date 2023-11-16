using Testing;
using Microsoft.EntityFrameworkCore;
using Testing.Data.Entities;
using FluentValidation;
using O9d.AspNet.FluentValidation;
using System.Runtime.CompilerServices;
using System.Net;
using Testing.Data.Dtos;
using Testing.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppdbContext>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

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

app.UseAuthorization();

app.MapRazorPages();


var CitiesGroup = app.MapGroup("/api").WithValidationFilter();
CityEndpoints.AddCityApi(CitiesGroup);
var RegionGroup = app.MapGroup("/api/cities/{cityId}").WithValidationFilter();
RegionEndpoints.AddRegionApi(RegionGroup);
var LocationGroup = app.MapGroup("/api/cities/{cityId}/regions/{regionId}").WithValidationFilter();
LocationEnpoints.AddLocationApi(LocationGroup);


app.Run();


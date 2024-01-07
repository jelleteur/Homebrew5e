using Homebrew5e.Core;
using Homebrew5e.Core.Collections;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.Core.Models;
using Homebrew5e.Dal;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//gebruik van cookies opzetten
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.Cookie.Name = "Homebrew5e.Session";
	options.IdleTimeout = TimeSpan.FromMinutes(20);
});

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ItemCollection>();
builder.Services.AddScoped<IDnDUserRepository, DnDUserRepository>();
builder.Services.AddScoped<DnDUserCollection>();
builder.Services.AddScoped<Item>();


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

app.Run();


using BlazorAppWSAM.Server.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Added to Get SQL Connection String
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Get the NavigationManager service from the app's service provider
//var app1 = builder.Build();
//var navigationManager = app1.Services.GetRequiredService<NavigationManager>();


var baseAddress = builder.Configuration.GetSection("BaseAddress").Value;

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
builder.Services.AddScoped<IImageLibraryRepository, ImageLibraryRepository>();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "AllowBlazorOrigin",
//        policy =>
//        {
//            policy.WithOrigins("https://localhost:7193", "http://localhost:7193");  //set the allowed origin  
//        });
//});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(baseAddress).AllowAnyMethod().AllowAnyHeader();  //set the allowed origin  
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseCors(policy =>
//    policy.WithOrigins("https://blazorappwsamserver20230704093213.azurewebsites.net", "https://blazorappwsamserver20230704093213.azurewebsites.net")
//    .AllowAnyMethod()
//    );

app.UseCors(policy =>
    policy.WithOrigins(baseAddress)
    .AllowAnyMethod()
    .AllowAnyHeader()
    );

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
//app.UseCors(options => options.AllowAnyOrigin());
//app.UseCors("AllowBlazorOrigin");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

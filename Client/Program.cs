using BlazorAppWSAM.Client;
using BlazorAppWSAM.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//var baseAddress = "https://blazorappwsamserver20230704093213.azurewebsites.net";
var baseAddress = builder.HostEnvironment.BaseAddress;

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); //This is the Original
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7193") });
//builder.Services.AddHttpClient<IToDoListService, ToDoListService>(client =>
//{
//    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
//});


builder.Services.AddHttpClient<IToDoListService, ToDoListService>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddHttpClient<IImageLibraryService, ImageLibraryService>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

await builder.Build().RunAsync();

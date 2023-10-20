using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LasPollasHermanas.Client;
using LasPollasHermanas.Client.Data;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5222") });
builder.Services.AddScoped<DildoClient>();
builder.Services.AddScoped<UserClient>();
builder.Services.AddScoped<CompradosClient>();
await builder.Build().RunAsync();

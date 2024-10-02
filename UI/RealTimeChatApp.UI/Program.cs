using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RealTimeChatApp.UI;
using RealTimeChatApp.UI.Auth.Implementations;
using RealTimeChatApp.UI.Auth.Interfaces;
using RealTimeChatApp.UI.Provider;
using RealTimeChatApp.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7274/") });
builder.Services.AddScoped<ApiService>();
builder.Services.AddSingleton<SignalRService>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IStorage, Storage>();
builder.Services.AddScoped<IAuth, Auth>();

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();


await builder.Build().RunAsync();

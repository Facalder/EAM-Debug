using System.Globalization;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using EAM.Client.Services;
using EAM.Shared.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Components.Tooltip;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

builder.Services.AddScoped(typeof(IDialogService), typeof(DialogService));
builder.Services.AddScoped(typeof(IMessageService), typeof(MessageService));
builder.Services.AddScoped(typeof(IToastService), typeof(ToastService));
builder.Services.AddScoped(typeof(ITooltipService), typeof(TooltipService));

builder.Services.AddScoped(typeof(LibraryConfiguration), typeof(LibraryConfiguration));
builder.Services.AddScoped(typeof(GlobalState), typeof(GlobalState));

builder.Services.AddScoped<IAssetRepository, AssetService>();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("id-ID");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("id-ID");

await builder.Build().RunAsync();
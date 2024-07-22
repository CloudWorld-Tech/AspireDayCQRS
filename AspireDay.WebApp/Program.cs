using AspireDay.ServiceDefaults;
using AspireDay.WebApp.Clients;
using AspireDay.WebApp.Components;
using AspireDay.WebApp.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddSyncfusionBlazor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<StoreApiClient>(client => client.BaseAddress = new Uri("http://webapi"));
builder.Services.AddSingleton<ISessionService, SessionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
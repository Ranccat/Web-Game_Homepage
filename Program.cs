using GameWeb.Components;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Interactive Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    
// DB Context
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddSingleton<CircuitHandler, UserCircuitHandler>();
builder.Services.AddSingleton<UserSessionService>();
builder.Services.AddScoped<UserService>();

// Loggers
builder.Logging.ClearProviders(); // clear deafult logger
builder.Logging.AddConsole(); // add console
builder.Logging.AddDebug(); // add debug

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

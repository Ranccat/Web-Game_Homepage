using GameWeb.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Interactive Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// DB Context
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Services
builder.Services.AddScoped<UserService>();

builder.Logging.ClearProviders(); // 기본 로거를 지우고
builder.Logging.AddConsole(); // 콘솔 로깅 추가
builder.Logging.AddDebug(); // 디버그 로깅 추가

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

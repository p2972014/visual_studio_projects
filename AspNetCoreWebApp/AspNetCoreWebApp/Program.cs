using AspNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using TransientScopedSingleton;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//---

builder.Services.AddDbContext<m_db1Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//---

builder.Services.AddTransient<ITransientService, OperationService>();
builder.Services.AddScoped<IScopedService, OperationService>();
builder.Services.AddSingleton<ISingletonService, OperationService>();

//---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

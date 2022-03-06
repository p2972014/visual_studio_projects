using AspNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using AspNetCoreWebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();

//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy;
//});

builder.Services.AddRazorPages();

//---

var _InDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
var _ConnectionString_key = _InDocker ? "DefaultConnection_docker" : "DefaultConnection";
var _key_Docker_Db_Development_Password = @"Docker:Db:Development:Password";
var tmp_ConnectionString_3 = builder.Configuration.GetConnectionString(_ConnectionString_key) ?? String.Empty;
var tmp_Env_Docker_db_password = Environment.GetEnvironmentVariable(_key_Docker_Db_Development_Password);
var tmp_Cfg_Db_Development_Password = builder.Configuration.GetValue<string>(_key_Docker_Db_Development_Password);
var _ConnectionString = tmp_ConnectionString_3.Replace(@"{" + _key_Docker_Db_Development_Password + "}",
    //tmp_Env_Docker_db_password
    tmp_Cfg_Db_Development_Password
    );

builder.Services.AddDbContext<m_db1Context>(options => options.UseSqlServer(_ConnectionString));

//---

builder.Services.AddTransient<ITransientService, OperationService>();
builder.Services.AddScoped<IScopedService, OperationService>();
builder.Services.AddSingleton<ISingletonService, OperationService>();
builder.Services.AddHostedService<myHostedService>();

//---

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

//---

app.UseMiddleware<MyMiddleware1>();
app.UseMiddleware<MyMiddleware2>();

//---

app.Logger.LogInformation("_InDocker = " + _InDocker);
app.Logger.LogInformation("tmp_Env_Docker_db_password = " + tmp_Env_Docker_db_password);
app.Logger.LogInformation("tmp_Cfg_Db_Development_Password = " + tmp_Cfg_Db_Development_Password);
app.Logger.LogInformation("_ConnectionString = " + _ConnectionString);

//---

app.Run();

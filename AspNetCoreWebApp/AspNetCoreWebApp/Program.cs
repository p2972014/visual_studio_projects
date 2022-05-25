using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using AspNetCoreWebApp.Middlewares;
using AspNetCoreWebApp.Models.db1;

//m7

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
var _key_Docker_Db_Development_Password = @"Docker_Db_Development_Password";
var tmp_ConnectionString_template = builder.Configuration.GetConnectionString(_ConnectionString_key) ?? String.Empty;
var tmp_Env_Docker_db_password = Environment.GetEnvironmentVariable(_key_Docker_Db_Development_Password); // èç Environment variables
var tmp_Cfg_Docker_db_password = builder.Configuration.GetValue<string>(_key_Docker_Db_Development_Password); // èç User Secrets file
var tmp_Docker_db_password =
    String.IsNullOrEmpty(tmp_Env_Docker_db_password) == false
    ? tmp_Env_Docker_db_password
    : tmp_Cfg_Docker_db_password;
var _ConnectionString = tmp_ConnectionString_template.Replace(@"{" + _key_Docker_Db_Development_Password + "}", tmp_Docker_db_password);

builder.Services.AddDbContext<m_db1Context>(options => options.UseSqlServer(_ConnectionString));
//builder.Services.AddDbContext<m_db1Context>(options => options.UseInMemoryDatabase(databaseName: "m_mem_db1"));

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

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

//---

// Migrate and seed the database during startup. Must be synchronous.
//try
//{
//    using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
//    {
//        serviceScope.ServiceProvider.GetService<m_db1Context>()?.Database.Migrate();
//    }
//}
//catch (Exception ex)
//{
//    app.Logger.LogError(ex, ex.Message);
//}

//---

//try
//{
//    // â îäíîì try catch íå ðàáîòàåò
//    using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
//    {
//        var db_context = serviceScope.ServiceProvider.GetService<m_db1Context>();

//        db_context?.MT1s.Add(new MT1() { MId = 1, MC1Text = "2", MC2Decimal = 3, MC3Date = new DateTime(2022, 03, 04) });
//        db_context?.SaveChanges();
//    }
//}
//catch (Exception ex)
//{
//    app.Logger.LogError(ex, ex.Message);
//}

//---

app.UseMiddleware<MyMiddleware1>();
app.UseMiddleware<MyMiddleware2>();

//---

app.Logger.LogInformation("_InDocker = " + _InDocker);
app.Logger.LogInformation("tmp_Env_Docker_db_password = " + tmp_Env_Docker_db_password);
app.Logger.LogInformation("tmp_Cfg_Docker_db_password = " + tmp_Cfg_Docker_db_password);
app.Logger.LogInformation("_ConnectionString = " + _ConnectionString);

//---

app.Run();

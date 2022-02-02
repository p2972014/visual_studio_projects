using AspNetCoreRedis.Logic;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//---

//builder.Services.AddDistributedMemoryCache();

//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = builder.Configuration.GetConnectionString("MyRedisConStr");
//    options.InstanceName = "SampleInstance";
//});

builder.Services.AddDistributedRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "name1";
});

//---

var app = builder.Build();

//---

app.Lifetime.ApplicationStarted.Register(
    async 
    () =>
    {
        await Redis.Set_cachedTimeUTC(app.Services.GetService<IDistributedCache>(), builder.Configuration);
    });

//---


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

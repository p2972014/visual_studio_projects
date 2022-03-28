using AspNetCoreWebAppOAuth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddIdentityServer(options =>
    {
        
    })
//InvalidOperationException: Unable to resolve service for type 'IdentityServer4.Stores.IClientStore' while attempting to activate 'IdentityServer4.Services.LogoutNotificationService'.
.AddClientStore<MyClientStore>() //обязательно
//InvalidOperationException: Unable to resolve service for type 'IdentityServer4.Stores.IResourceStore' while attempting to activate 'IdentityServer4.Validation.DefaultResourceValidator'.
.AddResourceStore<MyResourceStore>() //обязательно
;

builder.Services.AddAuthentication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();

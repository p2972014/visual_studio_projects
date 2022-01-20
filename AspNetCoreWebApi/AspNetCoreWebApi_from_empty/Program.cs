var builder = WebApplication.CreateBuilder(args);

//---

builder.Services.AddControllersWithViews();

//---

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//---

app.UseDefaultFiles(new DefaultFilesOptions() { DefaultFileNames = { @"myindex.html" } });
app.UseStaticFiles();

app.MapControllers();

//---

app.Run();

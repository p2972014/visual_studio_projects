var builder = WebApplication.CreateBuilder(args);

//---

builder.Services.AddControllers();

//---

var app = builder.Build();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(@"<html><a href=""api/Values"">default controller</a></html>");
}
);

//---

app.MapControllers();

//---

app.Run();

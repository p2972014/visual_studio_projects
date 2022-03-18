var builder = WebApplication.CreateBuilder(args);

//---

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

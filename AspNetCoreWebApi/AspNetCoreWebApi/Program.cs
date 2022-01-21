using AspNetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//---

var tmp_swagger_document_name = "mydocname1";
var tmp_route_template = "/swagger/{documentName}/swagger.json";
builder.Services.AddSwaggerGen(
    c =>
{
    c.SwaggerDoc(tmp_swagger_document_name,
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Title1",
            Version = "Version1",
            Description = "Description1"
        });
}
);

//---

builder.Services.AddDbContext<m_db1Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    app.UseSwagger(options =>
    {
        //options.SerializeAsV2 = true;
        options.RouteTemplate = tmp_route_template;
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(tmp_route_template.Replace("{documentName}", tmp_swagger_document_name), tmp_swagger_document_name);
        //options.RoutePrefix = String.Empty;
        options.RoutePrefix = @"myprefix1";
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ProductionReadyArrayListAPI.Project.Domain.Entities;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseCors("AllowAll");

// using (ApplicationContext db = new ApplicationContext())
// {
//
//     db.Users.ToList().Select(u => db.Users.Remove(db.Users.Find(u.Id))).ToList();
//     if (db.Users.ToList().Count == 0)
//     {
//         db.Users.Add(new User {Id=1, Name = "l0xa1", Email = "l0xa1@gmail.com", PasswordHash = "SBDFKSDKBFKJSDBfKJ"});
//         db.Users.Add(new User {Id=2, Name = "alutsn", Email = "alutsn@gmail.com", PasswordHash = "SBDFKSDKBFKJSDBfKJ"});
//     }
//     db.SaveChanges();
// }

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
    options.RoutePrefix = string.Empty;
});
app.MapControllers();
app.Run();
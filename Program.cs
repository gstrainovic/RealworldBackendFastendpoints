global using FastEndpoints;
global using FastEndpoints.Security;
global using FluentValidation;
global using MongoDB.Entities;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddJWTBearerAuth(builder.Configuration["JwtSigningKey"]);

builder.Services.AddSwaggerDoc();

var app = builder.Build();
app.UseFastEndpoints(c =>
{
  c.Endpoints.Configurator = ep =>
  {
    ep.PreProcessors(FastEndpoints.Order.Before, new ErrorLogger());
  };
});
// app.UseFastEndpoints(s => s.SerializerOptions = o => o.PropertyNamingPolicy = null);
app.UseDefaultExceptionHandler(); 
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerGen();

await DB.InitAsync(database: "conduit", host: "localhost");

app.Run();

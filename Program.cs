global using FastEndpoints;
global using FastEndpoints.Security;
global using FluentValidation;
global using MongoDB.Entities;
using System.Text.Json;
using AgileObjects.AgileMapper;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddJWTBearerAuth(JWT.jwtSigningKey);

builder.Services.AddSwaggerDoc();

var app = builder.Build();
// app.UseFastEndpoints();
app.UseFastEndpoints(c =>
{
  // c.Endpoints.Configurator = ep =>
  // {
  //   ep.PreProcessors(FastEndpoints.Order.Before, new ErrorHandler.EmptyRequest());
  // };
});
// app.MyExceptionHandler(); 
app.UseDefaultExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerGen();

await DB.InitAsync(database: "conduit", host: "localhost");

app.Run();

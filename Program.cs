global using FastEndpoints;
global using FastEndpoints.Security;
global using FluentValidation;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddJWTBearerAuth("TokenSigningKey$123234öä");

var app = builder.Build();
app.UseFastEndpoints(c =>
{
  c.Endpoints.Configurator = ep =>
  {
    ep.PreProcessors(Order.Before, new ErrorLogger());
  };
});
app.UseDefaultExceptionHandler(); 
app.UseAuthentication();
app.UseAuthorization();

app.Run();

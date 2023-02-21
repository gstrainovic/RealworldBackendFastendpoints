global using FastEndpoints;
global using FastEndpoints.Security;
global using FluentValidation;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddJWTBearerAuth("TokenSigningKey$123234öä");
// builder.Services.AddAuthorization(options =>
// {
//   options.AddPolicy("ManagersOnly", x => x.RequireRole("Manager").RequireClaim("UserName", "admin"));
// });

var app = builder.Build();

app.UseFastEndpoints(c =>
{
  c.Endpoints.Configurator = ep =>
  {
    ep.PreProcessors(Order.Before, new ErrorLogger());
  };
});



app.UseDefaultExceptionHandler(); //add this
app.UseAuthentication();
app.UseAuthorization();
// app.UseFastEndpoints(c =>
// {
//   c.Errors.ResponseBuilder = (failures, ctx, statusCode) =>
//   {
//     return new ValidationProblemDetails(
//           failures.GroupBy(f => f.PropertyName)
//                   .ToDictionary(
//                       keySelector: e => e.Key,
//                       elementSelector: e => e.Select(m => m.ErrorMessage).ToArray()))
//     {
//       Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
//       Title = "One or more validation errors occurred.",
//       Status = 422,
//       Instance = ctx.Request.Path,
//       Extensions = { { "traceId", ctx.TraceIdentifier } }
//     };
//   };
// });


app.Run();

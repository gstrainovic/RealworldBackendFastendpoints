global using FastEndpoints;
global using FastEndpoints.Security; //add this

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddJWTBearerAuth("TokenSigningKey$123234öä"); //add this
builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("ManagersOnly", x => x.RequireRole("Manager").RequireClaim("UserName", "admin"));
});

var app = builder.Build();
app.UseAuthentication(); //add this
app.UseAuthorization();
app.UseFastEndpoints();
app.Run();

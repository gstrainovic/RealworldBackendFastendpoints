using FastEndpoints.Security;
using FluentValidation.Results;

public class RegistrationEndpoint : Endpoint<RegisterRequest>
{
  public override void Configure()
  {
    Post("api/users");
    AllowAnonymous();
  }

  public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
  {

    var user = req.user;

    var jwtToken = JWTBearer.CreateToken(
        signingKey: "TokenSigningKey$123234öä",
        expireAt: DateTime.UtcNow.AddDays(1),
        priviledges: u =>
        {
          u.Roles.Add("User");
          // u.Permissions.AddRange(new[] { "ManageUsers", "ManageInventory" });
          // u.Claims.Add(new("email", user.email));
          // u["UserID"] = "001"; //indexer based claim setting
        });

    await user.SaveAsync();

    await SendAsync(new UserResponse
    {
      user = new UserResponse.User
      {
        email = user.email,
        token = jwtToken,
        username = user.username,
        bio = "I am the admin",
        image = ""
      }
    });
  }
}

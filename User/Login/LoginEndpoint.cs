using FastEndpoints.Security;
using FluentValidation.Results;

public class LoginEndpoint : Endpoint<LoginRequest>
{
  public override void Configure()
  {
    Post("api/users/login");
    AllowAnonymous();
  }

  public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
  {

    var user = req.user;

    if (user == null)
    {
      ThrowError("Body empty?");
    }

    if (user.email == "g.strainovic@gmail.com" && user.password == "password")
    {
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

      await SendAsync(new UserResponse
      {
        user = new UserResponse.User
        {
          email = user.email,
          token = jwtToken,
          username = "admin",
          bio = "I am the admin",
          image = ""
        }
      });
    }
    else
    {
      ThrowError("The supplied credentials are invalid!");
    }


  }


}

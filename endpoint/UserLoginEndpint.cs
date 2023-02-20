using FastEndpoints.Security;

public class UserLoginEndpoint : Endpoint<LoginRequest>
{
  public override void Configure()
  {
    Post("/api/login");
    AllowAnonymous();
  }

  public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
  {
    // if (await authService.CredentialsAreValid(req.Username, req.Password, ct))
    if (req.Username == "admin" && req.Password == "password")
    {
      var jwtToken = JWTBearer.CreateToken(
          signingKey: "TokenSigningKey$123234öä",
          expireAt: DateTime.UtcNow.AddDays(1),
          priviledges: u =>
          {
            u.Roles.Add("Manager");
            u.Permissions.AddRange(new[] { "ManageUsers", "ManageInventory" });
            u.Claims.Add(new("UserName", req.Username));
            u["UserID"] = "001"; //indexer based claim setting
          });

      await SendAsync(new
      {
        Username = req.Username,
        Token = jwtToken
      });
    }
    else
    {
      ThrowError("The supplied credentials are invalid!");
    }
  }
}
using FastEndpoints.Security;
using FluentValidation.Results;

public class UserLoginEndpoint : Endpoint<LoginRequest>
{
  public override void Configure()
  {
    Post("api/users/login");
    AllowAnonymous();
  }

  public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
  {

    

    //   failures.Add(new("body", "can't be empty"));
    //   await ctx.Response.SendErrorsAsync(failures, 422); 
    // if (req.user == null)
    //     // trow error with a custom message and status code 422
    //     ThrowError("The request body is empty!", 422);
      

    // // if body is empty then twrow error with a custom message
    // if (req.user.email == null || req.user.password == null || req == null)
    //   // throw and break
    //   ThrowError("The request body is empty!");
    // else {
      // print the request
      Console.WriteLine($"username: {req.user.email}");

      // if (await authService.CredentialsAreValid(req.Username, req.Password, ct))
      if (req.user.email == "g.strainovic@gmail.com" && req.user.password == "password")
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
            email = req.user.email,
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

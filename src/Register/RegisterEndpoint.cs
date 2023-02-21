using FastEndpoints.Security;
using FluentValidation.Results;

public class RegisterEndpoint : Endpoint<RegisterRequest, UserResponse>
{
  public override void Configure()
  {
    Post("api/users");
    AllowAnonymous();
  }

  public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
  {
    var user = Map.ToEntity(req.user);

    var emailIsTaken = await Data.EmailAddressIsTaken(user.email.ToLower());
    if (emailIsTaken)
      AddError(r => r.Email, "Email address is already in use");

    var userNameIsTaken = await Data.UserNameIsTaken(user.username.ToLower());
    if (userNameIsTaken)
      AddError(r => r.UserName, "Username is not available");

    ThrowIfAnyErrors();

    await user.SaveAsync();
    await SendAsync(new UserResponse
    {
      user = new UserResponse.User
      {
        email = user.email,
        token = JWT.CreateToken(),
        username = user.username,
        bio = "",
        image = ""
      }
    });
  }
}

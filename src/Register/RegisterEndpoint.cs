public class RegisterEndpoint : Endpoint<RegisterRequest, UserResponse>
{
  public override void Configure()
  {
    Post("api/users");
    AllowAnonymous();
  }

  public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
  {
    var emailIsTaken = await RegisterData.EmailAddressIsTaken(req.User.Email.ToLower());
    if (emailIsTaken)
      AddError(r => req.User.Email, "Email address is already in use");

    var userNameIsTaken = await RegisterData.UserNameIsTaken(req.User.UserName.ToLower());
    if (userNameIsTaken)
      AddError(r => req.User.UserName, "UserName is not available");

    ThrowIfAnyErrors();

    var user = new UserEntity
    {
      Email = req.User.Email.ToLower(),
      UserName = req.User.UserName.ToLower(),
      PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.User.Password)
    };

    await user.SaveAsync();

    await SendAsync(new UserResponse
    {
      User = new UserResponse.user
      {
        Email = user.Email,
        Token = JWT.CreateToken(user.Email),
        UserName = user.UserName,
        Bio = "",
        Image = ""
      }
    });

  }
}

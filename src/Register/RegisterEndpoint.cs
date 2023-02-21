public class RegisterEndpoint : Endpoint<RegisterRequest , UserResponse>
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

    var userNameIsTaken = await RegisterData.UserNameIsTaken(req.User.Username.ToLower());
    if (userNameIsTaken)
      AddError(r => req.User.Username, "Username is not available");

    ThrowIfAnyErrors();

    var user = new UserEntity
    {
      Email = req.User.Email.ToLower(),
      Username = req.User.Username.ToLower(),
      PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.User.Password)
    };

    await user.SaveAsync();

    // await SendAsync(new UserResponse
    // {
    //   user = new UserResponse.user
    //   {
    //     email = user.email,
    //     token = JWT.CreateToken(),
    //     username = user.username,
    //     bio = "",
    //     image = ""
    //   }
    // });

    await SendAsync(new UserResponse
    {
      User = new UserResponse.user
      {
        Email = user.Email,
        Token = JWT.CreateToken(),
        Username = user.Username,
        Bio = "",
        Image = ""
      }
    });

  }
}

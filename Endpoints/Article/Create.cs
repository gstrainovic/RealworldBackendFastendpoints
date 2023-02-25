namespace Endpoint.Article;

public class Create : Endpoint<Models.Request.User.Register, Models.Response.UserResponse>
{
  public override void Configure()
  {
    Post("api/articles");
    AllowAnonymous();
    DontThrowIfValidationFails();
  }

  public override async Task HandleAsync(Models.Request.User.Register req, CancellationToken ct)
  {

    var emailIsTaken = await Data.User.EmailAddressIsTaken(req.User.Email.ToLower());
    if (emailIsTaken)
      AddError(r => req.User.Email, "Email address is already in use");

    var userNameIsTaken = await Data.User.UsernameIsTaken(req.User.Username.ToLower());
    if (userNameIsTaken)
      AddError(r => req.User.Username, "Username is not available");

    ThrowIfAnyErrors();

    var user = new Ent.User
    {
      Email = req.User.Email.ToLower(),
      Username = req.User.Username.ToLower(),
      PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.User.Password)
    };

    await user.SaveAsync();

    await SendAsync(new Models.Response.UserResponse
    {
      User = new Models.Response.UserResponse.user
      {
        Email = user.Email,
        Token = JWT.CreateToken(user.Email),
        Username = user.Username
      }
    });

  }
}

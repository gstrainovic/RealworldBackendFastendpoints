namespace Endpoint.User;
public class Login : Endpoint<Models.Request.User.Login, Models.Response.UserResponse>
{
  public override void Configure()
  {
    Post("api/users/login");
    AllowAnonymous();
    DontThrowIfValidationFails();
  }

  public override async Task HandleAsync(Models.Request.User.Login r, CancellationToken c)
  {

    var user = await Data.User.GetByEmail(r.User.Email);

    if (user is null)
      ThrowError("No user account by that username!");

    if (!BCrypt.Net.BCrypt.Verify(r.User.Password, user.PasswordHash))
      ThrowError("Password is incorrect!");

    await SendAsync(new Models.Response.UserResponse
    {
      User = new Models.Response.UserResponse.user
      {
        Email = user.Email,
        Token = JWT.CreateToken(user.Email),
        Username = user.Username,
        Bio = user.Bio,
        Image = user.Image
      }
    });
  }
}
using System.Text.Json;
using FluentValidation.Results;

public class LoginEndpoint : Endpoint<LoginRequest, UserResponse>
{
  public override void Configure()
  {
    Post("api/users/login");
    AllowAnonymous();
    DontThrowIfValidationFails();
  }

  public override async Task HandleAsync(LoginRequest r, CancellationToken c)
  {

    var user = await DB.Find<Ent.User>()
        .Match(a => a.Email.ToLower() == r.User.email.ToLower())
        .ExecuteSingleAsync();

    if (user is null)
      ThrowError("No user account by that username!");

    if (!BCrypt.Net.BCrypt.Verify(r.User.password, user.PasswordHash))
      ThrowError("Password is incorrect!");

    await SendAsync(new UserResponse
    {
      User = new UserResponse.user
      {
        Email = user.Email,
        Token = JWT.CreateToken(user.Email),
        Username = user.UserName,
        Bio = user.Bio,
        Image = user.Image
      }
    });
  }
}
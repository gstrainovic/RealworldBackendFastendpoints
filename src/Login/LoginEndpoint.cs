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
    
    var user = await UserData.GetUser(r.User.Email);

    if (user is null)
      ThrowError("No user account by that username!");

    var hashing = new HashingManager();
    if (!hashing.Verify(r.User.Password, user.PasswordHash))
      ThrowError("Password is incorrect!");

    await SendAsync(new UserResponse
    {
      User = new UserResponse.user
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
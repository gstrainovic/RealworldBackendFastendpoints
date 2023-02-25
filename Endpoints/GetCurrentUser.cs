
using System.Security.Claims;

namespace Endpoint.User;

public class GetCurrent : EndpointWithoutRequest<Models.Response.UserResponse>
{
  public override void Configure()
  {
    Get("api/user");
    DontThrowIfValidationFails();
  }


  public override async Task HandleAsync(CancellationToken ct)
  {
    var UserEmail = User.FindFirstValue(ClaimName.UserEmail);
    var user = await Data.User.GetByEmail(UserEmail);

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



using System.Security.Claims;

public class GetCurrentUserEndPoint: EndpointWithoutRequest<UserResponse>
{
  public override void Configure()
{
  Get("api/user");
  DontThrowIfValidationFails();
}

public override async Task HandleAsync(CancellationToken ct)
{
  var UserEmail = User.FindFirstValue(ClaimName.UserEmail);
  var user = await UserData.GetUserByEmail(UserEmail);

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


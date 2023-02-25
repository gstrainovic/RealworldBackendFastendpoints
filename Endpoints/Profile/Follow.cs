using System.Security.Claims;

namespace Endpoint.Follow;

public class Profile : EndpointWithoutRequest<Models.Response.ProfileResponse>
{
  public override void Configure()
  {
    Post("api/profiles/{username}/follow");
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    string UserNameRequest = Route<string>("username");
    string CurrentUserEmail = User.FindFirstValue(ClaimName.UserEmail);
    await SendAsync(await Data.User.Follow(UserNameRequest, CurrentUserEmail, Data.User.EnumFollow.add));
  }
}
using System.Security.Claims;

namespace Endpoint.Profile;
public class UnFollow : EndpointWithoutRequest<Models.Response.ProfileResponse>
{
  public override void Configure()
  {
    Delete("api/profiles/{username}/follow");
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    string UserNameRequest = Route<string>("username");
    string CurrentUserEmail = User.FindFirstValue(ClaimName.UserEmail);
    await SendAsync(await Data.User.Follow(UserNameRequest, CurrentUserEmail, Data.User.EnumFollow.remove));
  }
}
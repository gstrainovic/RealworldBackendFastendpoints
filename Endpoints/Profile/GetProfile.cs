using System.Security.Claims;

namespace Endpoint.Profile;
public class Get : EndpointWithoutRequest<Models.Response.ProfileResponse>
{
  public override void Configure()
  {
    Get("api/profiles/{username}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    string UserNameRequest = Route<string>("username");
    string CurrentUserEmail = User.FindFirstValue(ClaimName.UserEmail);
    await SendAsync(await Data.User.Follow(UserNameRequest, CurrentUserEmail, Data.User.EnumFollow.ignore));
  }
}
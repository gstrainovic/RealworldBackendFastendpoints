using System.Security.Claims;
using System.Text.Json;
using AgileObjects.AgileMapper.Extensions;
using FastEndpoints;

public class GetProfileEndpoint : Endpoint<GetProfileRequest, ProfileResponse>
{
    public override void Configure()
    {
        Get("api/profiles/{username}");
        // DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(GetProfileRequest req, CancellationToken ct)
    {
        // print the request
        Console.WriteLine("request from GetProfileEndpoint" + JsonSerializer.Serialize(req));
        await SendOkAsync();
        // Ent.User user = await UserData.GetUserByUserName(req.Username);
        // string CurrentUserEmail = User.FindFirstValue(Claim.UserEmail);
        // Ent.User currentUser = await UserData.GetUserByEmail(CurrentUserEmail);
        // Boolean isFollowing = currentUser.Following.Contains(user.Email);
        // ProfileResponse.profile Response = user.Map().ToANew<ProfileResponse.profile>();
        // Response.following = isFollowing;
        // await SendAsync(new()
        // {
        //     Profile = Response
        // });
    }
}
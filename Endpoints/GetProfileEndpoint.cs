using System.Security.Claims;
using System.Text.Json;
using AgileObjects.AgileMapper.Extensions;
using FastEndpoints;

public class GetProfileEndpoint : EndpointWithoutRequest<ProfileResponse>
{
    public override void Configure()
    {
        Get("api/profiles/{username}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        string UserNameRequest = Route<string>("username");
        // print the username to the console
        Console.WriteLine("username: " + UserNameRequest);
        Ent.User UserFromRequest = await UserData.GetUserByUserName(UserNameRequest);
        // print the user to the console
        Console.WriteLine("user from request: " + JsonSerializer.Serialize(UserFromRequest));
        string CurrentUserEmail = User.FindFirstValue(ClaimName.UserEmail);
        // print the current user email to the console
        Console.WriteLine("current user email: " + CurrentUserEmail);
        Ent.User CurrentUser = await UserData.GetUserByEmail(CurrentUserEmail);
        // print the current user to the console
        Console.WriteLine("current user: " + JsonSerializer.Serialize(CurrentUser));
        Boolean isFollowing = CurrentUser.Following.Contains(UserFromRequest.Email);
        // print the isFollowing to the console
        Console.WriteLine("isFollowing: " + isFollowing);
        ProfileResponse.profile Response = UserFromRequest.Map().ToANew<ProfileResponse.profile>();
        Response.following = isFollowing;
        await SendAsync(new()
        {
            Profile = Response
        });
    }
}
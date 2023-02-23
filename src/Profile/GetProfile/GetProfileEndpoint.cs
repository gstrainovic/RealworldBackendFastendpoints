using System.Security.Claims;
using FastEndpoints;

public class Endpoint : Endpoint<GetProfileRequest, ProfileResponse, Mapper>
{
    public override void Configure()
    {
        Get("api/profiles/{Username}");
    }

    public override async Task HandleAsync(GetProfileRequest req, CancellationToken ct)
    {
        Ent.User user = await UserData.GetUserByUserName(req.Username);
        string CurrentUserEmail = User.FindFirstValue(Claim.UserEmail);
        Ent.User currentUser = await UserData.GetUserByEmail(CurrentUserEmail);
        Boolean isFollowing = currentUser.Following.Contains(user.Email);
        GetProfileResponse.Profile response = user.Map().ToANew<ProfileResponse.Profile>();
        response.Following = isFollowing;

        return SendOkAsync(Response, ct);
    }
}
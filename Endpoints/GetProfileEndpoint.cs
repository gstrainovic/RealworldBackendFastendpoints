﻿using System.Security.Claims;
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
        string CurrentUserEmail = User.FindFirstValue(ClaimName.UserEmail);
        await SendAsync(await UserData.Follow(UserNameRequest, CurrentUserEmail, FollowHandler.ignore));
    }
}
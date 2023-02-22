using AutoMapper;
using FastEndpoints;

namespace User;

public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UserResponse, UpdateUserMapper>
{
    public override void Configure()
    {
        Put("api/user");
    }

    public override Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
    {

      
    }
}
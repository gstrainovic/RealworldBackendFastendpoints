using FastEndpoints;

namespace User;

public class Endpoint : Endpoint<UpdateUserRequest, UserData>
{
    public override void Configure()
    {
        Put("api/user");
    }

    public override Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
    {

        return SendOkAsync(Response, ct);
    }
}
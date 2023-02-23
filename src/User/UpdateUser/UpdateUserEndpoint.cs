using System.Text.Json;
using AgileObjects.AgileMapper;
using AgileObjects.AgileMapper.Extensions;
using FastEndpoints;

namespace User;

public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UserResponse>
{
  public override void Configure()
  {
    Put("api/user");
    DontThrowIfValidationFails();
  }

  public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
  {

    
    var user = req.User.Map().ToANew<Ent.User>();
    var updated_user = await UserData.UpdateUser(user);
    var Response = updated_user.Map().ToANew<UserResponse.user>();
    await SendAsync(new UserResponse { User = Response });
  }
}
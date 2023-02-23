using System.Text.Json;
using AgileObjects.AgileMapper;
using AgileObjects.AgileMapper.Extensions;
using FastEndpoints;

namespace User;

public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UserResponse, UpdateUserMapper>
{
  public override void Configure()
  {
    Put("api/user");
    DontThrowIfValidationFails();
  }

  public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
  {
    Ent.User user = Map.ToEntity(req);
    Ent.User updated_user = await UserData.UpdateUser(user);
    UserResponse.user response = updated_user.Map().ToANew<UserResponse.user>();
    response.Token = JWT.CreateToken(response.Email);
    await SendAsync( new()
    {
      User = response
    });
  }
}
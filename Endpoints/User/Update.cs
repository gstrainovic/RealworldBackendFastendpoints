using AgileObjects.AgileMapper.Extensions;

namespace Endpoint.User;

public class Update : Endpoint<Models.Request.User.RegisterOrUpdate, Models.Response.UserResponse, Mapper.User.Update>
{
  public override void Configure()
  {
    Put("api/user");
    DontThrowIfValidationFails();
  }

  public override async Task HandleAsync(Models.Request.User.RegisterOrUpdate req, CancellationToken ct)
  {
    Ent.User user = Map.ToEntity(req.User);
    Ent.User updated_user = await Data.User.Update(user);
    Models.Response.UserResponse.user response = updated_user.Map().ToANew<Models.Response.UserResponse.user>();
    response.Token = JWT.CreateToken(response.Email);
    await SendAsync(new()
    {
      User = response
    });
  }
}
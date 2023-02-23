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


  }
}
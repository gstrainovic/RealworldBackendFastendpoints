using System.Security.Claims;

public class GetCurrentUserEntpoint : EndpointWithoutRequest<UserResponse>
{
  public override void Configure()
  {
    Get("api/user");
    // AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    // get the UserID from Claim
    var username = User.FindFirstValue(Claim.UserEmail);

    // print username
    Console.WriteLine(username);

    var user = await DB.Find<UserEnt>()
        .Match(a => a.Email.ToLower() == username.ToLower())
        .ExecuteSingleAsync();

    await SendAsync(new UserResponse
    {
      User = new UserResponse.user
      {
        Email = user.Email,
        Token = JWT.CreateToken(user.Email),
        Username = user.UserName,
        Bio = user.Bio,
        Image = user.Image
      }
    });

  }
}


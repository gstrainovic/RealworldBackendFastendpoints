public class GetCurrentUserEntpoint : EndpointWithoutRequest<UserResponse>
{
  public override void Configure()
  {
    Post("api/user");
    // AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {

    // get the user which is logged in from the database
    var user = await DB.Find<UserEntity>()
        .Match(a => a.Email.ToLower() == User.Identity.Name.ToLower())
        .ExecuteSingleAsync();


    await SendAsync(new UserResponse
    {
      User = new UserResponse.user
      {
        Email = user.Email,
        Token = JWT.CreateToken(user.Email),
        UserName = user.UserName,
        Bio = user.bio,
        Image = user.image
      }
    });

  }
}

public class LoginEndpoint : Endpoint<RegisterRequest, UserResponse>
{
    public override void Configure()
    {
        Post("api/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest r, CancellationToken c)
    {
        var user = await DB.Find<UserEntity>()
            .Match(a => a.Username.ToLower() == r.User.Username.ToLower())
            .ExecuteSingleAsync();

        if (user is null)
            ThrowError("No user account by that username!");

        if (!BCrypt.Net.BCrypt.Verify(r.User.Password, user.PasswordHash))
            ThrowError("Password is incorrect!");

        await SendAsync(new UserResponse
        {
          User = new UserResponse.user
          {
            Email = user.Email,
            Token = JWT.CreateToken(),
            Username = user.Username,
            Bio = user.Bio,
            Image = user.Image
          }
        });
    }
}
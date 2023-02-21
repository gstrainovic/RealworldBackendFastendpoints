namespace Admin.Login;

public class Endpoint : Endpoint<RegisterRequest, UserResponse>
{
    public override void Configure()
    {
        Post("api/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest r, CancellationToken c)
    {
        user = await DB.Find<Dom.User>().ManyAsync(u => u.email == email);

        if (user.passwordhash is null)
            ThrowError("No user account by that username!");

        if (!BCrypt.Net.BCrypt.Verify(r.password, passwordhash))
            ThrowError("Password is incorrect!");

        await SendAsync(new UserResponse
        {
          user = new UserResponse.User
          {
            email = user.email,
            token = JWT.CreateToken(),
            username = user.username,
            bio = user.bio,
            image = user.image
          }
        });
    }
}
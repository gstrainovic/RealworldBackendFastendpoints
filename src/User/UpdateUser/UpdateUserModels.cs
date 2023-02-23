using FastEndpoints;

public class UpdateUserRequest
{
  // {
  // "user":{
  //   "email": "jake@jake.jake",
  //   "bio": "I like to skateboard",
  //   "image": "https://i.stack.imgur.com/xHWG8.jpg"
  // }
  // }
  public user? User { get; set; }

  public class user
  {
    public string? Email { get; set; }
    public string? Bio { get; set; }
    public string? Image { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

  }
}

public class Validator : Validator<UpdateUserRequest>
{
  public Validator()
  {
    When(x => x.User != null, () =>
    {
      RuleFor(x => x.User.Email)
        .EmailAddress()
        .NotEmpty();

      RuleFor(x => x.User.Password)
        .MinimumLength(12);

    });

  }
}

public class UpdateUserResponse
{
  public string Message => "This endpoint hasn't been implemented yet!";
}

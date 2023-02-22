public class LoginRequest
{
  public user? User { get; set; }
  public class user
  {
    // required
    public string? Email { get; set; }

    // required
    public string? Password { get; set; }
  }
}

public class LoginRequestValidator : Validator<LoginRequest>
{
  public LoginRequestValidator()
  {

    When(x => x.User != null, () =>
    {
      RuleFor(x => x.User.Email)
        .EmailAddress()
        .NotEmpty();

      RuleFor(x => x.User.Password)
        .MinimumLength(12)
        .NotEmpty();
    });

  }
}

public class LoginRequest
{
  public user User { get; set; } = new();
  public class user 
  {
    public string Email { get; set; }  = string.Empty;
    public string Password { get; set; } = string.Empty;
  }
}

public class LoginRequestValidator : Validator<LoginRequest>
{
  public LoginRequestValidator()
  {

    When(x => x.User != null, () =>
    {
      RuleFor(x => x.User.Email)
          .NotEmpty();

      RuleFor(x => x.User.Password)
          .NotEmpty();
    });

  }
}

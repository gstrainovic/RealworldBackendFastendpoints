public class LoginRequest
{
  public user? User { get; set; }
  public class user 
  {
    public string? email { get; set; }
    public string? password { get; set; }
  }
}

public class LoginRequestValidator : Validator<LoginRequest>
{
  public LoginRequestValidator()
  {


    When(x => x.User != null, () =>
    {
      RuleFor(x => x.User.email)
          .NotEmpty();

      RuleFor(x => x.User.password)
          .NotEmpty();
    });

  }
}

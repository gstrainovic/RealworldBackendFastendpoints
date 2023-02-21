
public class LoginRequestValidator : Validator<LoginRequest>
{
  public LoginRequestValidator()
  {

    When(x => x.user != null, () =>
    {
      RuleFor(x => x.user.email)
          .NotEmpty();

      RuleFor(x => x.user.password)
          .NotEmpty();
    });

  }
}

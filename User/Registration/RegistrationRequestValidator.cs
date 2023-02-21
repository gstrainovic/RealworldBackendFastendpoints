
public class RegisterRequestValidator : Validator<RegisterRequest>
{
  public RegisterRequestValidator()
  {

    When(x => x.user != null, () =>
    {

      RuleFor(x => x.user.username)
          .NotEmpty();

      RuleFor(x => x.user.email)
          .NotEmpty();

      RuleFor(x => x.user.password)
          .NotEmpty();
    });

  }
}

public class RegisterRequest
{
  public user User { get; set; } = new();
  public class user
  {
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }
}
public class RegisterRequestValidator : Validator<RegisterRequest>
{
  public RegisterRequestValidator()
  {

    When(x => x.User != null, () =>
    {

      RuleFor(x => x.User.Username)
                   .NotEmpty();

      RuleFor(x => x.User.Email)
                   .NotEmpty();

      RuleFor(x => x.User.Password)
                   .NotEmpty();
    });

  }
}
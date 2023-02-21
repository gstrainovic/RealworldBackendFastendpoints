public class RegisterRequest
{
  public user User { get; set; } = new();
  public class user
  {
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? Image { get; set; }
  }
}
public class RegisterRequestValidator : Validator<RegisterRequest>
{
  public RegisterRequestValidator()
  {

    When(x => x.User != null, () =>
    {

      RuleFor(x => x.User.UserName)
                   .NotEmpty();

      RuleFor(x => x.User.Email)
                   .NotEmpty();

      RuleFor(x => x.User.Password)
                   .NotEmpty();
    });

  }
}
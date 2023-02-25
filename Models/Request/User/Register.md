namespace Models.Request.User;

public class Register
{
  public user? User { get; set; }
  public class user
  {
    // required
    public string? Username { get; set; }

    // required
    public string? Email { get; set; }

    // required
    public string? Password { get; set; }
  }

  public class Validator : Validator<Register>
  {
    public Validator()
    {

      When(x => x.User != null, () =>
      {

        RuleFor(x => x.User.Username)
          .NotEmpty();

        RuleFor(x => x.User.Email)
          .EmailAddress()
          .NotEmpty();

        RuleFor(x => x.User.Password)
          .MinimumLength(12)
          .NotEmpty();
      });

    }
  }
}
namespace Models.Request.User;

public class RegisterOrUpdate
{
  public user? User { get; set; }
  public class user : Model.Abstract.User.Base
  {
    public string? Password { get; set; }
  }

  public class Validator : Validator<RegisterOrUpdate>
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
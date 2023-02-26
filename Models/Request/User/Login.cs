namespace Models.Request.User;
public class Login
{
  public user? User { get; set; }
  public class user : Models.Abstract.User
  {
    public string? Password { get; set; }
  }
  
  public class Validator : Validator<Login>
  {
    public Validator()
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
}

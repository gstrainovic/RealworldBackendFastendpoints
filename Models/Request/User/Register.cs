namespace Models.Request.User;

// register request with all fields from Ent.User
public class Register
{
  public user? User { get; set; }
  
  

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
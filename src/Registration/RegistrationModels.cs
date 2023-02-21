// {
//   "user":{
//     "email": "jake@jake.jake",
//     "password": "jakejake"
//   }
// }

public class RegisterRequest
{
  public User user { get; set; } 
  public class User 
  {
    public string username { get; set; }
    public string email { get; set; } 
    public string password { get; set; } 
  }
}


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

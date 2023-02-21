// {
//   "user":{
//     "email": "jake@jake.jake",
//     "password": "jakejake"
//   }
// }
public class LoginRequest
{
  public User user { get; set; } 
  public class User 
  {
    public string email { get; set; } 
    public string password { get; set; } 
  }
}

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

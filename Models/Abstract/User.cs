namespace Model.Abstract.User;

public abstract class Base
{
  public string Email { get; set; }
  public string Username { get; set; }
  public string Bio { get; set; }
  public string Image { get; set; }
}

public abstract class BaseAndPassword : Base
{
  public string Password { get; set; }
}

public abstract class BaseAndHashPassword : Base
{
  public string PasswordHash { get; set; }
}

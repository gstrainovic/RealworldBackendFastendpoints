namespace Models.Response;
public class UserResponse
{
  public user? User { get; set; }
  public class user : Model.Abstract.User.Base
  {
    public string? Token { get; set; }
  }
}

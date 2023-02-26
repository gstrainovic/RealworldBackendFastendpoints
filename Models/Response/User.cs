namespace Models.Response;
public class UserResponse
{
  public user? User { get; set; }
  public class user : Model.Abstract.User
  {

    // remove the property id after the user is created
    public string? Token { get; set; }
  }
}

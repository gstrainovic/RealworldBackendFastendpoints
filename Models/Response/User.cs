namespace Models.Response;
public class UserResponse
{
  public user? User { get; set; }
public class user
{
  public string? Email { get; set; }

  // required
  public string? Token { get; set; }

  public string? Username { get; set; }
  public string? Bio { get; set; }
  public string? Image { get; set; }
}
}

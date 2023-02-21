public class UserResponse
{
  public user User { get; set; } = new();
  public class user
  {
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? Image { get; set; }
  }
}

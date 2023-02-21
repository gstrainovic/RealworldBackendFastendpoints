public class UserEntity : Entity
{
  public string Email { get; set; } = string.Empty;
  public string Username { get; set; } = string.Empty;
  public string? Bio { get; set; }
  public string? Image { get; set; }
  public string PasswordHash { get; set; } = string.Empty;
}


namespace Ent;

public class User : Entity
{
  public string Email { get; set; } = string.Empty;
  public string UserName { get; set; } = string.Empty;
  public string? Bio { get; set; }
  public string? Image { get; set; }
  public string PasswordHash { get; set; } = string.Empty;
}


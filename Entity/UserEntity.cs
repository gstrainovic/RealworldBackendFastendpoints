namespace Ent;

public class User : Entity
{
  public string? Email { get; set; }
  public string? Username { get; set; }
  public string? Bio { get; set; }
  public string? Image { get; set; }
  public HashSet<string> Following { get; set; } = new HashSet<string>();
  public string? PasswordHash { get; set; }
}


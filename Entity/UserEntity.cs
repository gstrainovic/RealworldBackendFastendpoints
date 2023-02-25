namespace Ent;

public class User : Entity
{
  public string? Email { get; set; }

  public string? Username { get; set; }

  public string? Bio { get; set; }

  public string? Image { get; set; } 

  public string? PasswordHash { get; set; }

  // which email adress i'm following
  // public HashSet<string> Following { get; set; } = new(); 
  
  // Following without duplicates



}


namespace Ent;

public class Article : Entity
{
  public string? Title { get; set; }
  public string? Slug { get; set; }
  public string? Description { get; set; }
  public string? Body { get; set; }
  public HashSet<string> TagList { get; set; } = new();
  public DateTime CreatedAt { get; set; } 
  public DateTime UpdatedAt { get; set; } 
  public bool Favorited { get; set; }
  public int FavoritesCount { get; set; }
  public One<Ent.User>? Author { get; set; }
}
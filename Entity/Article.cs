namespace Ent;

public class Article : Entity , ICreatedOn, IModifiedOn
{
  public string? Title { get; set; }
  public string? Slug { get; set; }
  public string? Description { get; set; }
  public string? Body { get; set; }
  public HashSet<string> TagList { get; set; } = new();
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  public bool Favorited { get; set; }
  public int FavoritesCount { get; set; }
  public One<Ent.User>? Author { get; set; }
}
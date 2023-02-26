namespace Models.Abstract;

public abstract class Article
{
  public string? Slug { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public string? Body { get; set; }
  public HashSet<string> TagList { get; set; } = new();
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public bool Favorited { get; set; }
  public int FavoritesCount { get; set; }
  public Ent.User? Author { get; set; }
}

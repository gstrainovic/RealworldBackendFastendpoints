namespace Mapper.Article;

public class Create : Mapper<Models.RequestResponse.ArticleRequestResponse.article, Models.RequestResponse.ArticleRequestResponse.article, Ent.Article>
{

  public override Ent.Article ToEntity(Models.RequestResponse.ArticleRequestResponse.article r) => new()

  {
    Title = r.Title,
    Slug = r.Slug ?? r.Title.ToLower().Replace(" ", "-"),
    Description = r.Description,
    Body = r.Body,
    TagList = r.TagList,
    CreatedAt = r.CreatedAt ?? DateTime.Now,
    UpdatedAt = r.UpdatedAt ?? DateTime.Now,
    Favorited = r.Favorited,
    FavoritesCount = r.FavoritesCount,
    Author = r.Author
  };

}
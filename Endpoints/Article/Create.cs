using System.Security.Claims;
using AgileObjects.AgileMapper.Extensions;

namespace Endpoint.Article;

public class Create : Endpoint<Models.RequestResponse.ArticleRequestResponse,  Models.RequestResponse.ArticleRequestResponse>
{
  public override void Configure()
  {
    Post("api/articles");
    DontThrowIfValidationFails();
  }

  public override async Task HandleAsync(Models.RequestResponse.ArticleRequestResponse req, CancellationToken ct)
  {
    string UserEmail = User.FindFirstValue(ClaimName.UserEmail);
    Ent.User user = await Data.User.GetByEmail(UserEmail);
    Ent.Article article = req.Article.Map().ToANew<Ent.Article>();

    if (article.Author == null) {
      article.Author = user;
    }

    if (article.Slug == null) {
      article.Slug = await Data.Article.CreateSlug(article.Title);
    }

    await article.SaveAsync();
    article.Author = user ?? req.Article.Author;

    await SendAsync(new Models.RequestResponse.ArticleRequestResponse
    {
      Article = article.Map().ToANew<Models.RequestResponse.ArticleRequestResponse.article>()
    });





  }
}

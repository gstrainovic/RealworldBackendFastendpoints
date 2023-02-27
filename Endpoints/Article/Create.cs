using System.Security.Claims;
using System.Text.Json;
using AgileObjects.AgileMapper.Extensions;

namespace Endpoint.Article;

public class Create : Endpoint<Models.RequestResponse.ArticleRequestResponse,  Models.RequestResponse.ArticleRequestResponse, Mapper.Article.Create>
{
  public override void Configure()
  {
    Post("api/articles");
    DontThrowIfValidationFails();
  }

  public override async Task HandleAsync(Models.RequestResponse.ArticleRequestResponse req, CancellationToken ct)
  {

    Console.WriteLine($"Request: {JsonSerializer.Serialize(req)}");

    // user
    string UserEmail = User.FindFirstValue(ClaimName.UserEmail);
    Ent.User user = await Data.User.GetByEmail(UserEmail);
    Console.WriteLine($"User: {JsonSerializer.Serialize(user)}");

    // If Author is not set in the request, so we need to get it from the current user
    Ent.User author = req.Article.Author ?? user;
    Console.WriteLine($"Author: {JsonSerializer.Serialize(author)}");
    req.Article.Author = author;

    // article
    Ent.Article article = Map.ToEntity(req.Article);
    Console.WriteLine($"Article: {JsonSerializer.Serialize(article)}");
    await article.SaveAsync();

    // response
    var response = article.Map().ToANew<Models.RequestResponse.ArticleRequestResponse.article>();
    response.Author = await article.Author.ToEntityAsync();
    await SendAsync(new Models.RequestResponse.ArticleRequestResponse
    {
      Article = response
    });




  }
}

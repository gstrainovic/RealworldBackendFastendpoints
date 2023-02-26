namespace Models.RequestResponse;

// {
//   "article": {
//     "title": "How to train your dragon",
//     "description": "Ever wonder how?",
//     "body": "You have to believe",
//     "tagList": ["reactjs", "angularjs", "dragons"]
//   }
// }

public class ArticleRequestResponse
{
  public article? Article { get; set; }
  public class article : Models.Abstract.Article
  {
  }
  public class Validator : Validator<ArticleRequestResponse>
  {
    public Validator()
    {
      When(x => x.Article != null, () =>
      {
        RuleFor(x => x.Article.Title)
          .NotEmpty();
        RuleFor(x => x.Article.Description)
          .NotEmpty();
        RuleFor(x => x.Article.Body)
          .NotEmpty();
      });
    }
  }
}
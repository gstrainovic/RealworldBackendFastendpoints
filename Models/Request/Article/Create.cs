namespace Models.Request.Article;

// {
//   "article": {
//     "title": "How to train your dragon",
//     "description": "Ever wonder how?",
//     "body": "You have to believe",
//     "tagList": ["reactjs", "angularjs", "dragons"]
//   }
// }

public class Create
{
  public article? Article { get; set; }
  public class article
  {
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Body { get; set; }
    public HashSet<string>? TagList { get; set; }
  }
  public class Validator : Validator<Create>
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
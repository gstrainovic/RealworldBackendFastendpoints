using System.Security.Claims;
using System.Text.Json;
using AgileObjects.AgileMapper.Extensions;

namespace Data;

public class Article
{
  public static Task<String>CreateSlug(string title)
  {
    return Task.FromResult(title.ToLower().Replace(" ", "-"));
  }
}

// enum follow

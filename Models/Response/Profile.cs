namespace Models.Response;

public class ProfileResponse
{
  // {
  // "profile": {
  //   "username": "jake",
  //   "bio": "I work at statefarm",
  //   "image": "https://api.realworld.io/images/smiley-cyrus.jpg",
  //   "following": false
  // }
  // }
  public profile? Profile { get; set; }
  public class profile : Model.Abstract.User
  {
    public bool Following { get; set; }
  }
}


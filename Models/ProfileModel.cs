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
  public class profile
  {
    public string? username { get; set; }
    public string? bio { get; set; }
    public string? image { get; set; }
    public bool following { get; set; }
  }

}




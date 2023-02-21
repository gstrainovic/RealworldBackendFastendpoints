namespace Dom;

public class User : Entity
{
    public string email { get; set; }
    public string token { get; set; }
    public string username { get; set; }
    public string bio { get; set; }
    public string image { get; set; }
}

// {
//   "user": {
//     "email": "jake@jake.jake",
//     "token": "jwt.token.here",
//     "username": "jake",
//     "bio": "I work at statefarm",
//     "image": null
//   }
// }
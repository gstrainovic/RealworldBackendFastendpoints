// {
//   "user":{
//     "email": "jake@jake.jake",
//     "password": "jakejake"
//   }
// }

public class LoginRequest
{
  public User user { get; set; } 
  public class User 
  {
    public string email { get; set; } 
    public string password { get; set; } 
  }
}
// {
//   "user":{
//     "email": "jake@jake.jake",
//     "password": "jakejake"
//   }
// }

public class RegisterRequest
{
  public User user { get; set; } 
  public class User 
  {
    public string username { get; set; }
    public string email { get; set; } 
    public string password { get; set; } 
  }
}
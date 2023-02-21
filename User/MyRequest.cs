public class MyRequest
{

  public User user { get; set; } 

  public class User {
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int Age { get; set; }
  }
}


public class UserData
{
  public static async Task<Ent.User> GetUserByEmail(string email)
  {
    return await DB.Find<Ent.User>()
        .Match(a => a.Email.ToLower() == email.ToLower())
        .ExecuteSingleAsync();
  }

  public static async Task<Ent.User> GetUserByUserName(string username)
  {
    return await DB.Find<Ent.User>()
        .Match(a => a.Username.ToLower() == username.ToLower())
        .ExecuteSingleAsync();
  }

  public static async Task<Ent.User> UpdateUser(Ent.User user)
  {
    return await DB.UpdateAndGet<Ent.User>()
      .Match(a => a.Email.ToLower() == user.Email.ToLower())
      .ModifyWith(user)
      .ExecuteAsync();
  }

}
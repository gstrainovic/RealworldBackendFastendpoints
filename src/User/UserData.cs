
public class UserData
{
  public static async Task<UserEnt> GetUser(string email)
  {
    var user = await DB.Find<UserEnt>()
        .Match(a => a.Email.ToLower() == email.ToLower())
        .ExecuteSingleAsync();
    return user;
  }

  public static async Task<UserEnt> UpdateUser(UserEnt user)
  {

    return await DB.UpdateAndGet<UserEnt>()
      .Match(a => a.Email.ToLower() == user.Email.ToLower())
      .ModifyWith(user)
      .ExecuteAsync();
    
  }

}
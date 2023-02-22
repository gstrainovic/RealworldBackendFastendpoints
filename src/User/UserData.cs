
public class UserData
{
  public static async Task<UserEnt> GetUser(string email)
  {
    var user = await DB.Find<UserEnt>()
        .Match(a => a.Email.ToLower() == email.ToLower())
        .ExecuteSingleAsync();
    return user;
  }

  public static async Task<UserEnt> UpdateUser(UserEnt user, UpdateUserRequest req)
  {
    user.Email = req.User.Email;
    user.Bio = req.User.Bio;
    user.Image = req.User.Image;
    user.Username = req.User.Username;
    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.User.Password);

    await DB.Update<UserEnt>()
      .Match(a => a.Email.ToLower() == user.Email.ToLower())
      .Modify(a => a.Email, user.Email)
      .Modify(a => a.Bio, user.Bio)
      .Modify(a => a.Image, user.Image)
      .Modify(a => a.Username, user.Username)
      .Modify(a => a.PasswordHash, user.PasswordHash)
      .ExecuteAsync();
    
    return user;
  }

}
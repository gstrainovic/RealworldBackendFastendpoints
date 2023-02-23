using System.Security.Claims;
using AgileObjects.AgileMapper.Extensions;

public enum FollowHandler
{
  add,
  remove,
  ignore
}

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

  public static async Task<ProfileResponse> Follow(string UserNameRequest, string CurrentUserEmail, FollowHandler follow)
  {
    Ent.User UserFromRequest = await GetUserByUserName(UserNameRequest);
    ProfileResponse.profile Response = UserFromRequest.Map().ToANew<ProfileResponse.profile>();

    if (CurrentUserEmail != null)
    {
          Ent.User currentUser = await GetUserByEmail(CurrentUserEmail);
          if (follow == FollowHandler.add)
          {
            currentUser.Following.Add(UserFromRequest.Email);
            await currentUser.SaveAsync();
          }
          else if (follow == FollowHandler.remove)
          {
            currentUser.Following.Remove(UserFromRequest.Email);
            await currentUser.SaveAsync();
          }
          Response.following = currentUser.Following.Contains(UserFromRequest.Email);
    }

    return new()
    {
      Profile = Response
    };
  }

}

// enum follow

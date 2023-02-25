using System.Security.Claims;
using System.Text.Json;
using AgileObjects.AgileMapper.Extensions;

namespace Data;

public class User
{

  public enum EnumFollow
  {
    add,
    remove,
    ignore
  }

  public static async Task<bool> EmailAddressIsTaken(string email)
  {
    return await DB
        .Find<Ent.User>()
        .Match(a => a.Email.ToLower() == email)
        .ExecuteAnyAsync();
  }

  public static async Task<bool> UsernameIsTaken(string loweCaseUsername)
  {
    return await DB
        .Find<Ent.User>()
        .Match(a => a.Username.ToLower() == loweCaseUsername)
        .ExecuteAnyAsync();
  }

  public static async Task<Ent.User> GetByEmail(string email)
  {
    return await DB.Find<Ent.User>()
        .Match(a => a.Email.ToLower() == email.ToLower())
        .ExecuteSingleAsync();
  }

  public static async Task<Ent.User> GetByUserName(string username)
  {
    return await DB.Find<Ent.User>()
        .Match(a => a.Username.ToLower() == username.ToLower())
        .ExecuteSingleAsync();
  }

  public static async Task<Ent.User> Update(Ent.User user)
  {
    return await DB.UpdateAndGet<Ent.User>()
      .Match(a => a.Email.ToLower() == user.Email.ToLower())
      .ModifyWith(user)
      .ExecuteAsync();
  }

  public static async Task<Models.Response.ProfileResponse> Follow(string UserNameRequest, string CurrentUserEmail, EnumFollow follow)
  {

    Console.WriteLine("UserNameRequest: " + UserNameRequest);
    Console.WriteLine("CurrentUserEmail: " + CurrentUserEmail);
    Console.WriteLine("follow: " + follow);

    Ent.User UserFromRequest = await GetByUserName(UserNameRequest);
    Console.WriteLine("UserFromRequest: " + JsonSerializer.Serialize(UserFromRequest));

    Models.Response.ProfileResponse.profile Response = UserFromRequest.Map().ToANew<Models.Response.ProfileResponse.profile>();
    Console.WriteLine("Response: " + JsonSerializer.Serialize(Response));

    if (CurrentUserEmail != null)
    {
      Ent.User currentUser = await GetByEmail(CurrentUserEmail);
      Console.WriteLine("currentUser: " + JsonSerializer.Serialize(currentUser));
      if (follow == EnumFollow.add)
      {
        currentUser.Following.Add(UserFromRequest.Email);
        await currentUser.SaveAsync();
      }
      else if (follow == EnumFollow.remove)
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

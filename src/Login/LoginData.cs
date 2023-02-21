public static class LoginData
{
    internal static Task<User> GetUser(string email)
    {
      return await DB.Find<Dom.User>().ManyAsync(u => u.email == email);
    }
}
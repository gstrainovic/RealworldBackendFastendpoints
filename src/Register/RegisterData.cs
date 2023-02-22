﻿public static class RegisterData
{
  internal static Task<bool> EmailAddressIsTaken(string email)
  {
    return DB
        .Find<UserEnt>()
        .Match(a => a.Email.ToLower() == email)
        .ExecuteAnyAsync();
  }

  internal static Task<bool> UserNameIsTaken(string loweCaseUserName)
  {
    return DB
        .Find<UserEnt>()
        .Match(a => a.UserName.ToLower() == loweCaseUserName)
        .ExecuteAnyAsync();
  }
}

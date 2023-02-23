public static class RegisterData
{
  internal static Task<bool> EmailAddressIsTaken(string email)
  {
    return DB
        .Find<Ent.User>()
        .Match(a => a.Email.ToLower() == email)
        .ExecuteAnyAsync();
  }

  internal static Task<bool> UsernameIsTaken(string loweCaseUsername)
  {
    return DB
        .Find<Ent.User>()
        .Match(a => a.Username.ToLower() == loweCaseUsername)
        .ExecuteAnyAsync();
  }
}

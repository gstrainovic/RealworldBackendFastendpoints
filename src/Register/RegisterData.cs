public static class RegisterData
{
    internal static Task<bool> EmailAddressIsTaken(string email)
    {
        return DB
            .Find<Dom.User>()
            .Match(a => a.Email == email)
            .ExecuteAnyAsync();
    }

    internal static Task<bool> UserNameIsTaken(string loweCaseUserName)
    {
        return DB
            .Find<Dom.User>()
            .Match(a => a.UserName.ToLower() == loweCaseUserName)
            .ExecuteAnyAsync();
    }
}

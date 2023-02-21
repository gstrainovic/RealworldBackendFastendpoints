namespace Registration;

public static class Data
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

    internal static Task CreateNewUser(Dom.User user)
    {
        return user.SaveAsync();
    }
}

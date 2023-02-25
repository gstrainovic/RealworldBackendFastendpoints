public static class ClaimName
{
  public const string UserEmail = "UserEmail";
}

public static class JWT
{
    // random jst signing key
    public static string jwtSigningKey = RandomString(32);

  private static string RandomString(int v)
  {
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, v)
      .Select(s => s[new Random().Next(s.Length)]).ToArray());
  }

  public static string CreateToken(string Email)
    {
    // load Configuration
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

    // load JWT Signing Key


    return JWTBearer.CreateToken(
          signingKey: jwtSigningKey,
          expireAt: DateTime.UtcNow.AddDays(1),
          claims: (ClaimName.UserEmail, Email)
        );
  }
}


public static class ClaimName
{
  public const string UserEmail = "UserEmail";
}

public static class JWT
{
    public static string CreateToken(string Email)
    {
    // load Configuration
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

    // load JWT Signing Key
    var jwtSigningKey = config["JwtSigningKey"];

    return JWTBearer.CreateToken(
          signingKey: jwtSigningKey,
          expireAt: DateTime.UtcNow.AddDays(1),
          claims: (ClaimName.UserEmail, Email)
        );
  }
}


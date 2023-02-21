// public static CreateToken()
// {
//   return JWTBearer.CreateToken(
//       signingKey: Config["JwtSigningKey"],
//       expireAt: DateTime.UtcNow.AddDays(1),
//       priviledges: u =>
//       {
//         u.Roles.Add("User");
//       });
// }

public static class JWT
{
    public static string CreateToken()
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
          priviledges: u =>
          {
            u.Roles.Add("User");
          });
  }
}
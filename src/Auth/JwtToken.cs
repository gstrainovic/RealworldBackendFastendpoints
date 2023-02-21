namespace JWT;

public function CreateToken()
{
  return JWTBearer.CreateToken(
      signingKey: Config["JwtSigningKey"],
      expireAt: DateTime.UtcNow.AddDays(1),
      priviledges: u =>
      {
        u.Roles.Add("User");
      });
}
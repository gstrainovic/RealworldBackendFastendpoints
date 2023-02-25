namespace Mapper.User;

public class Update : Mapper<Models.Request.User.RegisterOrUpdate.user, Models.Response.UserResponse.user, Ent.User>
{

  public override Ent.User ToEntity(Models.Request.User.RegisterOrUpdate.user r) => new()

  {
    Email = r.Email,
    Username = r.Username,
    Bio = r.Bio,
    Image = r.Image,
    PasswordHash = BCrypt.Net.BCrypt.HashPassword(r.Password)
  };

}
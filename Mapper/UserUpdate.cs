namespace Mapper.User;

public class Update : Mapper<Models.Request.User.Update, Models.Response.UserResponse, Ent.User>
{

  public override Ent.User ToEntity(Models.Request.User.Update r) => new()

  {
    Email = r.User.Email,
    Username = r.User.Username,
    Bio = r.User.Bio,
    Image = r.User.Image,
    PasswordHash = BCrypt.Net.BCrypt.HashPassword(r.User.Password)
  };

}
public class UpdateUserMapper : Mapper<UpdateUserRequest, UserResponse, Ent.User>
{

  public override Ent.User ToEntity(UpdateUserRequest r) => new()

  {
    Email = r.User.Email,
    Username = r.User.Username,
    Bio = r.User.Bio,
    Image = r.User.Image,
    PasswordHash = BCrypt.Net.BCrypt.HashPassword(r.User.Password)
  };

}
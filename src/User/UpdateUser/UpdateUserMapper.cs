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

  // public override UserResponse FromEntity(Ent.User e) => new()
  // {
  //   User = new UserResponse.user
  //   {
  //     Email = e.Email,
  //     Username = e.Username,
  //     Bio = e.Bio,
  //     Image = e.Image
  //   }
  // };
}
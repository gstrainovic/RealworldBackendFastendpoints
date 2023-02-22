public class UpdateUserMapper : Mapper<UpdateUserRequest, UpdateUserResponse, UserEnt>
{

  // var config = new MapperConfiguration(cfg =>
  //             cfg.CreateMap<UpdateUserRequest, UserEnt>()
  //         );
  // //Using automapper
  // var mapper = config.CreateMapper();
  // var mapper = new Mapper(config);
  // var user = mapper.Map<UserEnt>(req);

  // var updated_user = UserData.UpdateUser(user);

  

  public override Person ToEntity(Request r) => new()
  {
    Id = r.Id,
    DateOfBirth = DateOnly.Parse(r.BirthDay),
    FullName = $"{r.FirstName} {r.LastName}"
  };

  public override Response FromEntity(Person e) => new()
  {
    Id = e.Id,
    FullName = e.FullName,
    UserName = $"USR{e.Id:0000000000}",
    Age = (DateOnly.FromDateTime(DateTime.UtcNow).DayNumber - e.DateOfBirth.DayNumber) / 365,
  };
}
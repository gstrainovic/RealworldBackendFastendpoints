using AutoMapper;



public class Mapper
{
  // var config = new MapperConfiguration(cfg =>
  //             cfg.CreateMap<UpdateUserRequest, Ent.User>()
  //         );
  // //Using automapper
  // var mapper = config.CreateMapper();
  // var mapper = new Mapper(config);
  // var user = mapper.Map<Ent.User>(req);

  // var updated_user = UserData.UpdateUser(user);

  // generic automapper

  // static private void Condition(Func<TSource, TDestination, TMember, bool> condition



  public static TargetType Map<SourceType, TargetType>(object source)
  {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<SourceType, TargetType>()
          .ForMember(d => d.ValueLength, o => o.MapFrom(s => s != null ? s.Value.Length : 0))
          
      });


    // var config = new MapperConfiguration(cfg =>
    //     // cfg.CreateMap(typeof(SourceType), typeof(TargetType)).ForAllMembers(opt => opt.Condition(r => r != null))
    //     // cfg.ForAllMaps((obj, cnfg) => cnfg.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
    // // cfg.CreateMap<SourceType, TargetType>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))

    //     cfg.ForAllMaps((obj, cnfg) => cnfg.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));

    // );
    var mapper = config.CreateMapper();
    return mapper.Map<TargetType>(source);
  }

}
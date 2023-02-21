public class MyEndpoint : Endpoint<MyRequest>
{
  public override void Configure()
  {
    Post("/api/user/create");
    AllowAnonymous();
  }

  public override async Task HandleAsync(MyRequest req, CancellationToken ct)
  {
    var response = new MyResponse()
    {
      FullName = req.user.FirstName + " " + req.user.LastName,
      IsOver18 = req.user.Age > 18
    };

    await SendAsync(response);
  }
}

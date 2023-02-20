public class PersonEndpoint : EndpointWithoutRequest<PersonResponse>
{
  public override void Configure()
  {
    Get("/api/person");
    // AllowAnonymous();
    // ClaimsAll();
    // PermissionsAll();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var person = new PersonResponse
    {
      FullName = "John Doe",
      Age = 42
    };

    Response.FullName = person.FullName;
    Response.Age = person.Age;
  }
}
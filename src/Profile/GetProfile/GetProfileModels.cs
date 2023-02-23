public class GetProfileRequest
{
    public string Username { get; set; } = default!;

}

public class GetProfileValidator : Validator<GetProfileRequest>
{
    public GetProfileValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
    }
}



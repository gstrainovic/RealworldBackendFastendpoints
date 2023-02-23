public class GetProfileRequest
{
    public string? username { get; set; }

}

public class GetProfileValidator : Validator<GetProfileRequest>
{
    public GetProfileValidator()
    {
        RuleFor(x => x.username).NotEmpty();
    }
}

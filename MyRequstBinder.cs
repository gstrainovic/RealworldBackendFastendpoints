using FluentValidation.Results;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ErrorLogger : IGlobalPreProcessor
{
  public Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
  {
    // print the json request

    var json_string = JsonSerializer.Serialize(req);

    Console.WriteLine("json_string: " + json_string);

    return Task.CompletedTask;
  }
}
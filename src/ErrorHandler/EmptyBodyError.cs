using FluentValidation.Results;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ErrorLogger : IGlobalPreProcessor
{
  public Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
  {

    var json = JsonSerializer.Serialize(req);
    var json_object = JsonSerializer.Deserialize<JsonElement>(json);

    // check if the json object has an empty value like this: {"user":null}
    var has_empty_constructor = json_object.TryGetProperty("user", out var user) && user.ValueKind == JsonValueKind.Null;

    // If a request fails any validations, expect a 422 and errors in the following format:
    // {
    //   "errors":{
    //     "body": [
    //       "can't be empty"
    //     ]
    //   }
    // }
    if (has_empty_constructor) {
      failures.Add(new ValidationFailure("body", "can't be empty"));
      return ctx.Response.SendErrorsAsync(failures, 422);
    }

    return Task.CompletedTask;
  }


}


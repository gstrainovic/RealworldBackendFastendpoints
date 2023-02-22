using FluentValidation.Results;
using System.Text.Json;
using System.Text.Json.Serialization;

public class EmptyRequest : IGlobalPreProcessor
{
  public Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
  {

    var json = JsonSerializer.Serialize(req);

    // print the json to the console
    Console.WriteLine("Request2: " + req);

    // check if the json has a null like this {"User":null}
    var has_empty_constructor = json.Contains("null");



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


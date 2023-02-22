using System.Text.Json;
using FastEndpoints;
using FluentValidation.Results;
using Newtonsoft.Json.Linq;

public class ErrorLogger : IGlobalPostProcessor
{
  public Task PostProcessAsync(object req, object res, HttpContext ctx, IReadOnlyCollection<ValidationFailure> failures, CancellationToken ct)
  {

    Console.WriteLine("Request: " + JsonSerializer.Serialize(req));
    Console.WriteLine("Response: " + JsonSerializer.Serialize(res));
    Console.WriteLine("Failures: " + JsonSerializer.Serialize(failures));

    // var new_failure = new List<ValidationFailure>();
    // new_failure.Add(new ValidationFailure("body", "can't be empty"));
    // return ctx.Response.SendErrorsAsync(new_failure, 422);

    var json = JsonSerializer.Serialize(req).ToString();
    Console.WriteLine("Json from EmptyRequest " + json);


    if (json == "null" || json == "{}" || json == null)
    {
      var new_failure = new List<ValidationFailure>();
      new_failure.Add(new ValidationFailure("body", "can't be empty"));
      return ctx.Response.SendForbiddenAsync();
      // failures.Add(new ValidationFailure("body", "can't be empty"));
      // return ctx.Response.SendErrorsAsync(failures, 422);
    } else {
      return Task.CompletedTask;
    }


    // var json_object = JObject.Parse(json);

    // Console.WriteLine("Request from EmptyRequest: " + req);

    // var has_empty_constructor = json_object.Properties().Count() == 0;

    // // get the first property of the request object
    // var first_property_length = json_object.Properties().First().Value.ToString().Length;

    // Console.WriteLine("First property: " + first_property_length);

    // if (first_property_length == 0)
    // {
    //   var new_failure = new List<ValidationFailure>();
    //   new_failure.Add(new ValidationFailure("body", "can't be empty"));
    //   return ctx.Response.SendErrorsAsync(new_failure, 422);
    //   // failures.Add(new ValidationFailure("body", "can't be empty"));
    //   // return ctx.Response.SendErrorsAsync(failures, 422);
    // }
    // else
    // {
    //   return Task.CompletedTask;
    // }

  }
}
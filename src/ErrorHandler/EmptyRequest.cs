using FluentValidation.Results;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class EmptyRequest : IGlobalPreProcessor
{
  public Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
  {

    var json = JsonSerializer.Serialize(req);
    var json_object = JObject.Parse(json);

    // Console.WriteLine("Request from EmptyRequest: " + req);
    // Console.WriteLine("Json from EmptyRequest " + json);

    // var has_empty_constructor = json_object.Properties().Count() == 0;

    // get the first property of the request object
    var first_property_length = json_object.Properties().First().Value.ToString().Length;

    // Console.WriteLine("First property: " + first_property_length);

    // get the value of the first property
    // var first_property_empty = first_property.Value.ToString().Length == 0;


    // If a request fails any validations, expect a 422 and errors in the following format:
    // {
    //   "errors":{
    //     "body": [
    //       "can't be empty"
    //     ]
    //   }
    // }
    // if (has_empty_constructor) {
    //   failures.Add(new ValidationFailure("body", "can't be empty"));
    //   return ctx.Response.SendErrorsAsync(failures, 422);
    // }

    if (failures.Count > 0)
    {
      return ctx.Response.SendErrorsAsync(failures);
    }

    if (first_property_length == 0)
    {
      failures.Add(new ValidationFailure("body", "can't be empty"));
      return ctx.Response.SendErrorsAsync(failures,422);
    } else {
      return Task.CompletedTask;
    }
  }


}


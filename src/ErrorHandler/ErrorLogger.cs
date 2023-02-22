using System.Text.Json;
using FastEndpoints;
using FluentValidation.Results;

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

    var logger = ctx.RequestServices.GetService<ILogger<ErrorLogger>>();
    logger.LogError("Request: " + JsonSerializer.Serialize(req));
    logger.LogError("Response: " + JsonSerializer.Serialize(res));
    logger.LogError("Failures: " + JsonSerializer.Serialize(failures));

    return Task.CompletedTask;

    // if (req == null)
    // {

    //   // If a request fails any validations, expect a 422 and errors in the following format:
    //   // {
    //   //   "errors":{
    //   //     "body": [
    //   //       "can't be empty"
    //   //     ]
    //   //   }

    //   var new_failure = new List<ValidationFailure>();
    //   new_failure.Add(new ValidationFailure("body", "can't be empty"));
    //   return ctx.Response.SendErrorsAsync(new_failure, 422);
      

    // }

    // return Task.CompletedTask;

  }
}
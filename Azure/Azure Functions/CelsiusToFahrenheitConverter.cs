using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace TemperatureConverter
{
  public class CelsiusToFahrenheitConverter
  {
    private readonly ILogger<CelsiusToFahrenheitConverter> _logger;
    public CelsiusToFahrenheitConverter(ILogger<CelsiusToFahrenheitConverter> log)
    {
      _logger = log;
    }

    [FunctionName("CelsiusToFahrenheitConverter")]
    [OpenApiOperation(operationId: "Run", tags: new[] { "Conversion" })]
    [OpenApiParameter(name: "celsius", In = ParameterLocation.Path, Required = true, Type = typeof(double), Description = "This Azure Function will convert a Celsius input into a Fahrenheit output")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "Returns the Fahrenheit equivalent value")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "CelsiusToFahrenheitConverter/{celsius}")] HttpRequest req, double celsius)
    {
      double result = (celsius * 9) / 5 + 32;

      string responseMessage = $"The temperature {celsius.ToString(CultureInfo.InvariantCulture)}°C converted to Fahrenheit is {result.ToString("F2", CultureInfo.InvariantCulture)}°C";

      _logger.LogInformation($"Fahrenheit value received:{celsius}");

      return new OkObjectResult(responseMessage);
    }
  }
}


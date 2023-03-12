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
  public class FahrenheitToCelsiusConverter
  {
    private readonly ILogger<FahrenheitToCelsiusConverter> _logger;
    public FahrenheitToCelsiusConverter(ILogger<FahrenheitToCelsiusConverter> log)
    {
      _logger = log;
    }

    [FunctionName("FahrenheitToCelsiusConverter")]
    [OpenApiOperation(operationId: "Run", tags: new[] { "Conversion" })]
    [OpenApiParameter(name: "fahrenheit", In = ParameterLocation.Path, Required = true, Type = typeof(double), Description = "This Azure Function will convert a Fahrenheit input into a Celsius output")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "Returns the Celsius equivalent value")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "FahrenheitToCelsiusConverter/{fahrenheit}")] HttpRequest req, double fahrenheit)
    {
      double result = (fahrenheit - 32) * 5 / 9;

      string responseMessage = $"The temperature {fahrenheit.ToString(CultureInfo.InvariantCulture)}°F converted to Celsius is {result.ToString("F2", CultureInfo.InvariantCulture)}°C";

      _logger.LogInformation($"Fahrenheit value received:{fahrenheit}");

      return new OkObjectResult(responseMessage);
    }
  }
}


using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController()
    {
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] {"value1","value"};
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id) 
    {
        return "Masum";
    }


}

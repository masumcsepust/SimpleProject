using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public WeatherForecastController(ICustomerService cus)
    {
        _customerService=cus;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        var customers = await _customerService.List();

            return Ok(customers);
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id) 
    {
        return "masum";
    }


}

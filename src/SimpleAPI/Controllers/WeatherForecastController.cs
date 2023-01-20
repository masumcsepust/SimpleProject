using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Data;
using SimpleAPI.Models;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController()
    {
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public  ActionResult<string> Get()
    {
        return "Something new";
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id) 
    {
        return "masum";
    }


}

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
    //private readonly ICustomerService _customerService;
    private readonly DemoDbContext _dataContext;
    public WeatherForecastController(DemoDbContext cus)
    {
        _dataContext=cus;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        var customers = await _dataContext.customers
                                     .OrderBy(c => c.Name)
                                     .Select(c => new Customer
                                     { 
                                        Id = c.Id,
                                        Name = c.Name,
                                        Address = c.Address,
                                        Email = c.Email
                                     })
                                     .ToListAsync();

            return Ok(customers);
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id) 
    {
        return "masum";
    }


}

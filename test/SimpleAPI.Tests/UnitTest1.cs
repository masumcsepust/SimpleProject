using SimpleAPI.Controllers;

namespace SimpleAPI.Tests;

public class UnitTest1
{
    WeatherForecastController controller = new WeatherForecastController();
    [Fact] 
    public void Get() {
        var returnValue = controller.Get(1);
        Assert.Equal("masum", returnValue.Value);
    }
    [Fact]
    public void Test1()
    {

    }
}
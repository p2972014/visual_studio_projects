using BlazorServerApp.Data;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var ret = await (new WeatherForecastService()).GetForecastAsync(System.DateTime.Now);
            Assert.NotNull(ret);
            Assert.True(ret.Length>0);
        }
    }
}
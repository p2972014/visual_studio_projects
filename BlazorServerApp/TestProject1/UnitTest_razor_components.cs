using Xunit;
using Bunit;

namespace TestProject1
{
    public class UnitTest_razor_components
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            using var context = new TestContext();
           
            var page = context.RenderComponent<BlazorServerApp.Pages.Counter>();
            page.Find("#vsl_btn1").Click();
            var vsl_count_text = page.Find("#vsl_count_text");
            vsl_count_text.MarkupMatches(@"<p id=""vsl_count_text"" role=""status"">Current count: 1</p>");
        }
    }
}
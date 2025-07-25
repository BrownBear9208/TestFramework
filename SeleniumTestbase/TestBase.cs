using NUnit.Framework;

namespace SeleniumTestbase
{
    public abstract class TestBase
    {
        private const string BaseUrl = "https://magento.softwaretestingboard.com/";

        [SetUp]
        public void SetUp()
        {
            Browser.Init();
            Browser.Navigate(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Quit();
        }
    }
}

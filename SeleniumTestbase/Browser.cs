using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTestbase
{
    public class Browser
    {
        private static IWebDriver? _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    throw new NullReferenceException("Driver is not initialized. Call Init() first.");
                }

                return _driver;
            }
        }


        public static void Init()
        {
            string solutionRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;

            string crxPath = Path.Combine(solutionRoot, "SeleniumTestbase", "Extensions", "adblock.crx");


            if (_driver != null) return;

            ChromeOptions options = new ChromeOptions { AcceptInsecureCertificates = true, };
            options.AddArgument("--disable-search-engine-choice-screen");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--window-size=1920,1080");
            options.AddArguments("--host-resolver-rules=MAP *.doubleclick.net 127.0.0.1, MAP *.ads.google.com 127.0.0.1");
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            try
            {
                _driver = new ChromeDriver(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ChromeDriver failed to start: " + ex);
                throw;
            }
        }

        public static void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            _driver?.Quit();
            _driver = null;
        }

        public static WebDriverWait Wait(int timeoutMilliseconds = 35000, int pollingMilliseconds = 250)
        {
            WebDriverWait wait = new WebDriverWait(new SystemClock(), driver: _driver,
                TimeSpan.FromMilliseconds(timeoutMilliseconds), TimeSpan.FromMilliseconds(pollingMilliseconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(NotFoundException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait;
        }

        public static void NavigateToMenu(params string[] menuItemIds)
        {
            if (_driver == null) throw new NullReferenceException("Driver not initialized");

            Actions actions = new Actions(_driver);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            for (int i = 0; i < menuItemIds.Length; i++)
            {
                IWebElement menuItem = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(menuItemIds[i])));

                // Hover over the menu item
                actions.MoveToElement(menuItem).Perform();

                // If it's not the last element, wait for the next submenu to appear
                if (i + 1 < menuItemIds.Length)
                {
                    string nextMenuItemId = menuItemIds[i + 1];
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(nextMenuItemId)));
                }
                else
                {
                    // Last item: wait until it's clickable and click it
                    wait.Until(ExpectedConditions.ElementToBeClickable(menuItem)).Click();
                }
            }
        }

    }
}

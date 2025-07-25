using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTestbase
{
    public partial class WomenJacketsCategory(IWebDriver driver)
    {
        readonly Actions _actions = new Actions(driver);

        public WomenJacketsCategory WaitToLoad()
        {
            Browser.Wait().Until(drv => GetElement(_pageTitle).Text.Contains("Jackets", StringComparison.InvariantCultureIgnoreCase));
            return this;
        }

        public void AddProductToCart(string product, string color, string size)
        {
            Headers headers = new Headers(driver);
            int initialCartCounter = headers.GetCartCounterNumber();

            IWebElement selectedProduct = GetElement(GetProductItem(product));
            SelectSize(size, selectedProduct);
            SelectColor(color, selectedProduct);

            _actions.MoveToElement(selectedProduct);
            selectedProduct.FindElement(_addToCartButton).Click();

            Browser.Wait().Until(drv =>headers.GetCartCounterNumber() == initialCartCounter + 1);
        }

        private void SelectSize(string size, IWebElement product)
        {
            
            product.FindElement(GetProductSize(size)).Click();
        }

        private void SelectColor(string color, IWebElement product)
        {
            product.FindElement(GetColor(color)).Click();
        }




        /// <summary>
        /// Retrieves a single element using a specified locator.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns>IWebElement.</returns>
        private IWebElement GetElement(By locator)
        {
            try
            {
                return driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
    }
}

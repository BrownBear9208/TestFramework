using OpenQA.Selenium;

namespace SeleniumTestbase
{
    public partial class WomenJacketsCategory
    {

        private readonly By _pageTitle = By.CssSelector("span[data-ui-id='page-title-wrapper']");
        private readonly By _productList = By.ClassName("product-items");

        private By GetProductItem(string itemName) =>
            By.XPath($"//li[contains(@class,'product-item')][.//a[contains(@class,'product-item-link') and normalize-space(text())='{itemName}']]");


        private By GetColor(string productColor) => By.CssSelector($"div[option-label='{productColor}']");

        private By GetProductSize(string productSize) => By.CssSelector($"div[option-label='{productSize}']");

        private readonly By _addToCartButton = By.ClassName("tocart");
    }
}

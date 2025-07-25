using OpenQA.Selenium;

namespace SeleniumTestbase
{
    public partial class Checkout
    {
        private readonly By _email = By.Id("customer-email");
        private readonly By _firstName = By.CssSelector("input[name='firstname']");
        private readonly By _lastname = By.CssSelector("input[name='lastname']");
        private readonly By _address = By.CssSelector("input[name='street[0]']");
        private readonly By _city = By.CssSelector("input[name='city']");
        private readonly By _stateSelector = By.CssSelector("select[name='region_id']");
        private readonly By _postalCode = By.CssSelector("input[name='postcode']");
        private readonly By _phoneNumber = By.CssSelector("input[name='telephone']");
        private readonly By _radioFixed = By.CssSelector("input[type='radio'][value='flatrate_flatrate']");
        private readonly By _radioTableRate = By.CssSelector("input[type='radio'][value='tablerate_bestway']");
        private readonly By _nextButton = By.CssSelector("button[data-role='opc-continue']");
        private readonly By _placeOrder = By.CssSelector("button.action.primary.checkout");
        private readonly By _pageTitle = By.ClassName("page-title");
    }
}

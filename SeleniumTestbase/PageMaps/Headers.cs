using OpenQA.Selenium;

namespace SeleniumTestbase
{
    public partial class Headers
    {

        private readonly By _signIn = By.LinkText("Sign In");
        private readonly By _whatIsNew = By.Id("ui-id-3");
        private readonly By _womenMenu = By.Id("ui-id-4");
        private readonly By _topsMenu = By.Id("ui-id-9");
        private readonly By _jacketsMenu = By.Id("ui-id-11");
        private readonly By _hoodiesMenu = By.Id("ui-id-12");
        private readonly By _teesMenu = By.Id("ui-id-13");
        private readonly By _brasTanksMenu = By.Id("ui-id-14");

        private readonly By _consentFormDismiss = By.ClassName("fc-cta-consent");
        private readonly By _loggedInMessage = By.ClassName("logged-in");


        private readonly By _cartButton = By.ClassName("showcart");
        private readonly By _cartDropDownContainer = By.Id("ui-id-1");
        private readonly By _itemsTotal = By.ClassName("items-total");
        private readonly By _priceTotal = By.ClassName("price");
        private readonly By _proceedToCheckout = By.Id("top-cart-btn-checkout");
        private readonly By _deleteItem = By.ClassName("delete");
        private readonly By _acceptDeleteCartItem = By.ClassName("action-accept");
        private readonly By _cartLoading = By.ClassName("_block-content-loading");
        private readonly By _cartCounterNumber = By.ClassName("counter-number");
    }
}

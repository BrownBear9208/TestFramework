using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestbase;

namespace UiTests
{
    public class Testcases : TestBase
    {
        [Test]
        public void UnregisteredUsersCanPlaceOrders()
        {
            IWebDriver driver = Browser.Driver;

            Headers header = new Headers(driver);
            WomenJacketsCategory womenJacketsCategory = new WomenJacketsCategory(driver);
            Checkout checkout = new Checkout(driver);

            header.WaitToLoad();
            
            Browser.NavigateToMenu(MenuIds.Women, MenuIds.Tops,MenuIds.Jackets);
            
            womenJacketsCategory.WaitToLoad();

            womenJacketsCategory.AddProductToCart(Products.OliviaJacket, ProductColors.Black, ProductSizes.M);

            womenJacketsCategory.AddProductToCart(Products.JunoJacket, ProductColors.Green, ProductSizes.Xs);

            Assert.That(header.GetINumberOfItemsInCart(), Is.EqualTo(2));
            Assert.That(header.GetCartSubtotal(), Is.EqualTo("$154.00"));


            header.ProceedToCheckout();
            string email = "johndoe@anymail.com";
            string firstName = "John";
            string lastName = "Doe";
            string address = "34th Jasmine str";
            string city = "Night City";
            string state = "Delaware";
            string postalCode = "322420";
            string phoneNumber = "0722";
            bool isStandardShipping = true;

            checkout.WaitToLoad().InputEmail(email);
            checkout.InputFirstName(firstName);
            checkout.InputLastName(lastName);
            checkout.InputAddress(address);
            checkout.InputCity(city);
            checkout.SelectState(state);
            checkout.InputPostalCode(postalCode);
            checkout.InputPhoneNumber(phoneNumber);
            checkout.SelectShipping(isStandardShipping);

            checkout.GotToReviewAndPayments();

            checkout.PlaceOrder();

            Assert.That(driver.Url, Is.EqualTo("https://magento.softwaretestingboard.com/checkout/onepage/success/"));
            Assert.That(checkout.GetPageTitle(), Is.EqualTo("Thank you for your purchase!"));

        }
    }
}

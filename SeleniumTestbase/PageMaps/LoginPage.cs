using OpenQA.Selenium;

namespace SeleniumTestbase
{
    public partial class LoginPage
    {
        private By _emaiInput = By.Id("email");
        private By _passwordInput = By.Id("pass");
        private By _signInButton = By.Id("send2");
    }
}

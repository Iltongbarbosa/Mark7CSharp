namespace Mark7CSharp
{
    using OpenQA.Selenium;

    public class LoginPage
    {
        public readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Logar(string email, string senha)
        {
           _driver.FindElement(By.Id("login_email")).SendKeys(email);
           _driver.FindElement(By.Id("login_password")).SendKeys(senha);
           _driver.FindElement(By.CssSelector(".btn.btn-accent.loginButton")).Click();
        }

        public IWebElement MensagemFalhaLogin()
        {
            return _driver.FindElement(By.CssSelector(".alert-login div"));
        }
    }
}

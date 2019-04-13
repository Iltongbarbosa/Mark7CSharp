namespace Mark7CSharp
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Threading;

    public class Login
    {
        private ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://mark7.herokuapp.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test]
        public void SenhaInvalida()
        {
            
            IWebElement campoEmail = driver.FindElement(By.Id("login_email"));
            campoEmail.SendKeys("ilton.io@ninja.com.br");

            IWebElement campoSenha = driver.FindElement(By.Id("login_password"));
            campoSenha.SendKeys("654321");

            IWebElement botaoLogin = driver.FindElement(By.CssSelector(".btn.btn-accent.loginButton"));
            botaoLogin.Click();

            Thread.Sleep(500);

            IWebElement mensagem = driver.FindElement(By.CssSelector(".alert-login div"));

            Assert.True(mensagem.Text == "Incorrect password");
        }

        [Test]
        public void UsuarioInvalido()
        {

            IWebElement campoEmail = driver.FindElement(By.Id("login_email"));
            campoEmail.SendKeys("joao.das.neves@ninja.com.br");

            IWebElement campoSenha = driver.FindElement(By.Id("login_password"));
            campoSenha.SendKeys("123456");

            IWebElement botaoLogin = driver.FindElement(By.CssSelector(".btn.btn-accent.loginButton"));
            botaoLogin.Click();

            Thread.Sleep(500);

            IWebElement mensagem = driver.FindElement(By.CssSelector(".alert-login div"));

            Assert.True(mensagem.Text == "User not found");
        }

        [Test]
        public void UsuarioNaoInformado()
        {
            IWebElement campoSenha = driver.FindElement(By.Id("login_password"));
            campoSenha.SendKeys("123456");

            IWebElement botaoLogin = driver.FindElement(By.CssSelector(".btn.btn-accent.loginButton"));
            botaoLogin.Click();

            Thread.Sleep(500);

            IWebElement mensagem = driver.FindElement(By.CssSelector(".alert-login div"));

            Assert.True(mensagem.Text == "Email is required");
        }

        [Test]
        public void SenhaNaoInformada()
        {
            IWebElement campoEmail = driver.FindElement(By.Id("login_email"));
            campoEmail.SendKeys("ilton.io@ninja.com.br");

            IWebElement botaoLogin = driver.FindElement(By.CssSelector(".btn.btn-accent.loginButton"));
            botaoLogin.Click();

            Thread.Sleep(500);

            IWebElement mensagem = driver.FindElement(By.CssSelector(".alert-login div"));

            Assert.True(mensagem.Text == "Password is required");
        }

        [Test]
        public void LoginComSucesso()
        {

            IWebElement campoEmail = driver.FindElement(By.Id("login_email"));
            campoEmail.SendKeys("ilton.io@ninja.com.br");

            IWebElement campoSenha = driver.FindElement(By.Id("login_password"));
            campoSenha.SendKeys("123456");

            IWebElement botaoLogin = driver.FindElement(By.CssSelector(".btn.btn-accent.loginButton"));
            botaoLogin.Click();

            Thread.Sleep(1000);

            IWebElement mensagem = driver.FindElement(By.CssSelector("#task-board .panel-body h3"));

            Assert.True(mensagem.Text == "Hello, ilton");
        }
    }
}

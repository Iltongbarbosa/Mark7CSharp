namespace Mark7CSharp
{
    using Pages;
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [Category("Login")]
    public class Login
    {
        private ChromeDriver driver;
        private LoginPage loginPage;
        private TaskPage taskPage;
        private IWebElement mensagem { get; set; }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://mark7.herokuapp.com/");
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            taskPage = new TaskPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void SenhaInvalida()
        {
            loginPage.Logar("ilton.io@ninja.com.br", "654321");
            Assert.True(loginPage.MensagemFalhaLogin().Text == "Incorrect password");
        }

        [Test]
        public void UsuarioInvalido()
        {
            loginPage.Logar("joao.das.neves@ninja.com.br", "123456");
            Assert.True(loginPage.MensagemFalhaLogin().Text == "User not found");
        }

        [Test]
        public void UsuarioNaoInformado()
        {
            loginPage.Logar("", "123456");
            Assert.True(loginPage.MensagemFalhaLogin().Text == "Email is required");
        }

        [Test]
        public void SenhaNaoInformada()
        {
            loginPage.Logar("ilton.io@ninja.com.br", "");
            Assert.True(loginPage.MensagemFalhaLogin().Text == "Password is required");
        }

        [Test]
        public void LoginComSucesso()
        {
            loginPage.Logar("ilton.io@ninja.com.br", "123456");
            Assert.True(taskPage.BemVindo().Text == "Hello, ilton");
        }
    }
}

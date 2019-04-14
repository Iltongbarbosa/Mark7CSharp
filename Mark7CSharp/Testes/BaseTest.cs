namespace Mark7CSharp.Testes
{
    using Pages;
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class BaseTest
    {
        private ChromeDriver driver;
        public LoginPage loginPage;
        public TaskPage taskPage;

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
    }
}

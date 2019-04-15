namespace Mark7CSharp.Common
{
    using Pages;
    using System;
    using OpenQA.Selenium.Chrome;

    public class BaseSteps : IDisposable
    {
        public ChromeDriver driver;
        public LoginPage loginPage;
        public TaskPage taskPage;

        public BaseSteps()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://mark7.herokuapp.com/");
            driver.Manage().Window.Maximize();

            loginPage = new LoginPage(driver);
            taskPage = new TaskPage(driver);
        }

        
        public void Dispose()
        {
            driver.Quit();
        }
    }
}


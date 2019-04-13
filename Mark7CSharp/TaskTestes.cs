namespace Mark7CSharp
{

    using Pages;
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [Category("Cadastro Tarefas")]
    public class TaskTestes
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
        public void CadastrarTarefas()
        { string tarefa = "Estudar C#";

            loginPage.Logar("ilton.io@ninja.com.br", "123456");
            taskPage.CadastrarTarefa(tarefa, "28/10/2019");
            var res = taskPage.TarefaCadastrada(tarefa);
            Assert.True(res.Text.Contains(tarefa));
        }
    }
}

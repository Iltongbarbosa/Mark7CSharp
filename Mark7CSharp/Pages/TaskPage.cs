namespace Mark7CSharp.Pages
{
    using OpenQA.Selenium;
    using System;
    using System.Linq;

    public class TaskPage
    {
        private readonly IWebDriver _driver;

        public TaskPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BemVindo()
        {
            return _driver.FindElement(By.CssSelector("#task-board .panel-body h3"));
        }

        public void CadastrarTarefa(string nomeTask, string dataEntrega)
        {
            _driver.FindElement(By.Id("insert-button")).Click();

            _driver.FindElement(By.CssSelector("input[name=title]")).SendKeys(nomeTask);
            _driver.FindElement(By.CssSelector("input[name=dueDate]")).SendKeys(dataEntrega);
            _driver.FindElement(By.CssSelector("button[type=submit]")).Click();
        }

        public IWebElement TarefaCadastrada(string nomeTask)
        {
            var trs = _driver.FindElements(By.CssSelector("table tbody tr"));
            var alvo = trs.FirstOrDefault(tr => tr.Text.Contains(nomeTask));
            return alvo;
        }
    }
}

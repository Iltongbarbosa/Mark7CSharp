namespace Mark7CSharp.Pages
{
    using OpenQA.Selenium;
    using System;
    using System.Linq;
    using OpenQA.Selenium.Support.PageObjects;

    public class TaskPage
    {
        private readonly IWebDriver _driver;

        public TaskPage(IWebDriver driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "#task-board .panel-body h3")]
        private IWebElement MensagemBemVindo;

        public string BemVindo()
        {
            return MensagemBemVindo.Text;
        }

        public void CadastrarTarefa(string tarefa, string dataEntrega)
        {
            _driver.FindElement(By.Id("insert-button")).Click();

            _driver.FindElement(By.CssSelector("input[name=title]")).SendKeys(tarefa);
            _driver.FindElement(By.CssSelector("input[name=dueDate]")).SendKeys(dataEntrega);
            _driver.FindElement(By.CssSelector("button[type=submit]")).Click();
        }

        public IWebElement TarefaCadastrada(string tarefa)
        {
            var trs = _driver.FindElements(By.CssSelector("table tbody tr"));
            var alvo = trs.FirstOrDefault(tr => tr.Text.Contains(tarefa));

            if (alvo == null)
            {
                throw new ArgumentException("A tarefa não foi encontrada.");
            }

            return alvo;
        }

        public string MensagemTarefaDuplicada()
        {
            return _driver.FindElement(By.CssSelector(".alert-warn.panel .panel-body")).Text;
        }

        public string BuscarTarefa(string tarefa)
        {
            _driver.FindElement(By.Id("search-input")).SendKeys(tarefa); ;
            _driver.FindElement(By.Id("search-button")).Click();
  
            return _driver.FindElement(By.CssSelector("#task-board .panel.panel-filled.panel-c-warning")).Text;
        }

        public int RetornaQuantidadeRegistros()
        {
            return _driver.FindElements(By.CssSelector("table tbody tr")).Count;
        }

        public void CancelarCadastro(string tarefa, string dataEntrega)
        {
            _driver.FindElement(By.Id("insert-button")).Click();
            _driver.FindElement(By.CssSelector("input[name=title]")).SendKeys(tarefa);
            _driver.FindElement(By.CssSelector("input[name=dueDate]")).SendKeys(dataEntrega);

            _driver.FindElement(By.Id("form-cancel-button")).Click();
        }


        public IWebElement RemoverTarefa(string tarefa)
        {
            _driver.FindElement(By.Id("search-input")).SendKeys(tarefa);
            _driver.FindElement(By.Id("search-button")).Click();
            _driver.FindElement(By.Id("delete - button")).Click();
            return null;
        }
    }
}

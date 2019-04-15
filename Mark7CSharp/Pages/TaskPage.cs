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

        public IWebElement BemVindo()
        {
            return _driver.FindElement(By.CssSelector("#task-board .panel-body h3"));

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

        public string AltertaRetornoTarefa()
        {
            var res =  _driver.FindElement(By.CssSelector(".alert-warn.panel .panel-body")).Text;
            Voltar();
            return res;
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


        public void Voltar()
        {
            _driver.FindElement(By.Id("form-cancel-button")).Click();
        }

        public IWebElement BuscarRemoverUmaTarefa(string tarefa)
        {
            _driver.FindElement(By.Id("search-input")).SendKeys(tarefa);
            _driver.FindElement(By.Id("search-button")).Click();
            _driver.FindElement(By.Id("delete - button")).Click();
            return null;
        }

        public void RemoverTarefaGrid(string tarefa)
        {
            var res = this.TarefaCadastrada(tarefa);
            res.FindElement(By.Id("delete-button")).Click();
        }

        public void ConfirmarRemocaoTarefa()
        {
            _driver.FindElement(By.CssSelector(".modal-content button[data-bb-handler=success")).Click();
        }

        public void DesistirRemocaoTarefa()
        {
            _driver.FindElement(By.CssSelector(".modal-content button[data-bb-handler=danger")).Click();
        }
    }
}

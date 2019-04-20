namespace Mark7CSharp.Testes
{
    using OpenQA.Selenium;
    using NUnit.Framework;
    using OpenQA.Selenium.Support.PageObjects;

    [Category("Exclusão de tarefas NUnit")]
    public class ExclusaoTarefas : BaseTest
    {
        private IWebElement mensagem { get; set; }

        [SetUp]
        public void Before()
        {
            loginPage.Logar("ilton.io@ninja.com.br", "pwd123");
        }

        [Test]
        public void RemocaoTarefa()
        {
            var tarefa = new { Titulo = "Tarefa muito boa para ser removida " + Faker.Name.First(), Data = "28/10/2019" };
            taskPage.CadastrarTarefa(tarefa.Titulo, tarefa.Data);
            taskPage.RemoverTarefaGrid(tarefa.Titulo);
            taskPage.ConfirmarRemocaoTarefa();
            taskPage.BuscarTarefa(tarefa.Titulo);

            Assert.True("Hmm... no tasks found :(" == taskPage.RetornoTarefaNaoCadastrada());
        }

        [Test]
        public void DesistirRemocaoTarefa()
        {
            var tarefa = new { Titulo = "Tarefa para sera removida " + Faker.Name.First(), Data = "28/10/2019" };
            taskPage.CadastrarTarefa(tarefa.Titulo, tarefa.Data);
            taskPage.RemoverTarefaGrid(tarefa.Titulo);
            taskPage.DesistirRemocaoTarefa();
            Assert.True(taskPage.TarefaCadastrada(tarefa.Titulo).Text.Contains(tarefa.Titulo));
        }
    }
}

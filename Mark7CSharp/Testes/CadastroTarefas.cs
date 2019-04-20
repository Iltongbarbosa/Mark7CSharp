namespace Mark7CSharp
{
    using Testes;
    using Pages;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [Category("Cadastro Tarefas NUnit")]
    public class CadastroTarefas : BaseTest
    {
        private IWebElement mensagem { get; set; }

        [SetUp]
        public void Before()
        {
            loginPage.Logar("ilton.io@ninja.com.br", "pwd123");
        }

        [Test]
        public void CadastroTarefa()
        {
            var tarefa = new { Titulo = "Estudar C# " + Faker.Name.First(), Data = "28/10/2019" };

            taskPage.CadastrarTarefa(tarefa.Titulo, tarefa.Data);    
            Assert.True(taskPage.TarefaCadastrada(tarefa.Titulo).Text.Contains(tarefa.Titulo));
        }

        [Test]
        public void TarefaDuplicadaDeveExistirSomenteUmRegistro()
        {
            var tarefa = new { Titulo = "Tarefe deve ser Única " + Faker.Name.First(), Data = "28/10/2019" };
            taskPage.CadastrarTarefa(tarefa.Titulo, tarefa.Data);
            taskPage.CadastrarTarefa(tarefa.Titulo, tarefa.Data);
            Assert.True("Tarefa duplicada." == taskPage.AltertaRetornoTarefa());
            taskPage.BuscarTarefa(tarefa.Titulo);
            Assert.True(taskPage.RetornaQuantidadeRegistros() == 1);
        }

        [Test]
        public void TituloMuitoCurto()
        {
            var tarefa = new { Titulo = "Titulo", Data = "28/10/2019" };
            taskPage.CadastrarTarefa(tarefa.Titulo, tarefa.Data);
            Assert.True("10 caracteres é o mínimo permitido." == taskPage.AltertaRetornoTarefa());
        }

        [Test]
        public void DesistirCadastrarTarefa()
        {
            var tarefa = new { Titulo = "Estudar C# " + Faker.Name.First(), Data = "28/10/2019" };
            taskPage.CancelarCadastro(tarefa.Titulo, tarefa.Data);
            taskPage.BuscarTarefa(tarefa.Titulo);

            Assert.True("Hmm... no tasks found :(" == taskPage.RetornoTarefaNaoCadastrada());
        }
    }
}

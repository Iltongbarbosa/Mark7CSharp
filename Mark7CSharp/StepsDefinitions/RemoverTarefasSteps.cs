namespace Mark7CSharp.StepsDefinitions
{
    using Common;
    using Mark7CSharp;
    using NUnit.Framework;
    using TechTalk.SpecFlow;


    [Binding]
    public sealed class RemoverTarefasSteps : BaseSteps
    {
        public string Titulo {get; set;}
        public string Data { get; set; }

        [Given(@"que faço login com '(.*)' e '(.*)'")]
        public void DadoQueFacoLoginComE(string email, string senha)
        {
            loginPage.Logar(email, senha);
        }

        [Given(@"que tenho uma tarefa indesejada")]
        public void DadoQueTenhoUmaTarefaIndesejada()
        {
            Titulo = "Tarefa de " + Faker.Name.First();
            Data = "31/12/2019";
            taskPage.CadastrarTarefa(Titulo, Data);
        }

        [When(@"eu solicito a exclusão desta tarefa")]
        public void QuandoEuSolicitoAExclusaoDestaTarefa()
        {
            taskPage.RemoverTarefaGrid(Titulo);
        }

        [When(@"confirmo a ação de exclusão")]
        public void QuandoConfirmoAAcaoDeExclusao()
        {
            taskPage.ConfirmarRemocaoTarefa();
        }

        [Then(@"esta tarefa não deve ser exibida na lista")]
        public void EntaoEstaTarefaNaoDeveSerExibidaNaLista()
        {
            taskPage.BuscarTarefa(Titulo);
            Assert.True("Hmm... no tasks found :(" == taskPage.RetornoTarefaNaoCadastrada());
        }

        [When(@"eu cancelo esta ação")]
        public void QuandoEuCanceloEstaAcao()
        {
            taskPage.DesistirRemocaoTarefa();
        }

        [Then(@"esta tarefa permanece na lista")]
        public void EntaoEstaTarefaPermaneceNaLista()
        {
            Assert.True(taskPage.TarefaCadastrada(Titulo).Text.Contains(Titulo));
        }

    }
}

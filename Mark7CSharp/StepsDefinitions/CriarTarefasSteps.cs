namespace Mark7CSharp.StepsDefinitions
{
    using Common;
    using TechTalk.SpecFlow;
    using NUnit.Framework;

    public class Tarefa
    {
        public string Titulo { get; set; }
        public string Data { get; set; }
        public Table Tags { get; set; }
    }

    [Binding]
    public sealed class CriarTarefasSteps : BaseSteps
    {
        public static Tarefa tarefa = new Tarefa();
        private MongodbHelper mongo;

        [Given(@"que estou logado com '(.*)' e '(.*)'")]
        public void DadoQueEstouLogadoComE(string email, string senha)
        {
            loginPage.Logar(email, senha);
        }

        [Given(@"que eu tenho uma tarefa com os seguintes atributos:")]
        public void DadoQueEuTenhoUmaTarefaComOsSeguintesAtributos(Table Dados)
        {
            mongo = new MongodbHelper();

            foreach (var item in Dados.Rows)
            {
                tarefa.Titulo = item["Titulo"];
                tarefa.Data = item["Data"];
            }
            mongo.DeleteByTitle(tarefa.Titulo);
            taskPage.CadastrarTarefa2(tarefa);
        }

        [Given(@"eu quero taguear esta tarefa com:")]
        public void DadoEuQueroTaguetagsTarefaarEstaTarefaCom(Table tagsTarefa)
        {
            tarefa.Tags = tagsTarefa;
            taskPage.TaguearCadastrarTarefa(tarefa.Tags);
        }

        [When(@"faço o cadastro dessa tarefa")]
        public void QuandoFacoOCadastroDessaTarefa()
        {
            taskPage.SalvarTarefa();
        }

        [Then(@"devo ver está tarefa com o status '(.*)'")]
        public void EntaoDevoVerEstaTarefaComOStatus(string statusTarefa)
        {
            Assert.True(taskPage.TarefaCadastrada(tarefa.Titulo).Text.Contains(statusTarefa));
        }

        [Given(@"eu já cadastrei esta tarefa e não tinha percebido")]
        public void DadoEuJaCadastreiEstaTarefaENaoTinhaPercebido()
        {
            taskPage.SalvarTarefa();
            taskPage.CadastrarTarefa2(tarefa);
            taskPage.TaguearCadastrarTarefa(tarefa.Tags);
            taskPage.SalvarTarefa();
        }

        [Then(@"devo ver a mensagem '(.*)' ao tentar cadastrar")]
        public void EntaoDevoVerAMensagemAoTentarCadastrar(string mensagem)
        {
            Assert.True(mensagem == taskPage.AltertaRetornoTarefa());
        }

        [Then(@"devo ver somente (.*) tarefa com o nome cadastrado")]
        public void EntaoDevoVerSomenteTarefaComONomeCadastrado(int qtdTarefas)
        {
            taskPage.BuscarTarefa(tarefa.Titulo);
            Assert.True(taskPage.RetornaQuantidadeRegistros() == qtdTarefas);
        }

    }
}

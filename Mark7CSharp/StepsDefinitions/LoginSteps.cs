namespace Mark7CSharp.StepsDefinitions
{
    using TechTalk.SpecFlow;
    using Mark7CSharp.Common;
    using NUnit.Framework;

    [Binding]
    public sealed class LoginSteps : BaseSteps
    {
        [When(@"faço login com '(.*)' e '(.*)'")]
        public void QuandoFacoLoginComE(string email, string senha)
        {
            loginPage.Logar(email, senha.ToString());
        }

        [Then(@"sou redirecionado para o painel de tarefas com a mensagem '(.*)'")]
        public void EntaoSouRedirecionadoParaOPainelDeTarefasComAMensagem(string mensagem)
        {
            Assert.True(mensagem == taskPage.BemVindo().Text);
        }

        [Then(@"devo ver a mensagem de alerta '(.*)'")]
        public void EntaoDevoVerAMensagemDeAlerta(string mensagem)
        {
            Assert.True(loginPage.MensagemFalhaLogin().Text == mensagem);
        }

    }
}

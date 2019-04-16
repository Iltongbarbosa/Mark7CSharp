namespace Mark7CSharp.StepsDefinitions
{
    using TechTalk.SpecFlow;
    using Mark7CSharp.Common;
    using NUnit.Framework;

    [Binding]
    public sealed class LoginSteps : BaseSteps
    {
        static int indexLogin = 0, indexMensagens = 0;
        [When(@"faço login com '(.*)' e '(.*)'")]
        public void QuandoFacoLoginComE(string email, int senha)
        {
            loginPage.Logar(email, senha.ToString());
        }

        [Then(@"sou redirecionado para o painel de tarefas com a mensagem '(.*)'")]
        public void EntaoSouRedirecionadoParaOPainelDeTarefasComAMensagem(string mensagem)
        {
            Assert.True(mensagem == taskPage.BemVindo().Text);
        }

        [When(@"faço login com email e senha:")]
        public void QuandoFacoLoginComEmailESenha(Table tbDadosUsuario)
        {
            string email ="", senha = "";
            tbDadosUsuario.Rows[indexLogin].TryGetValue("email", out email);
            tbDadosUsuario.Rows[indexLogin].TryGetValue("senha", out senha);
            loginPage.Logar(email, senha.ToString());
            indexLogin++;
        }

        [Then(@"devo ver a mensagem de alerta saida:")]
        public void EntaoDevoVerAMensagemDeAlertaSaida(Table tbMensagem)
        {
            string mensagem = "";
            tbMensagem.Rows[indexMensagens].TryGetValue("saida", out mensagem);
            Assert.True(loginPage.MensagemFalhaLogin().Text == mensagem);
            indexMensagens++;
        }

    }
}

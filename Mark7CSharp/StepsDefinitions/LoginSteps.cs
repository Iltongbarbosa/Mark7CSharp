namespace Mark7CSharp.StepsDefinitions
{
    using TechTalk.SpecFlow;
    using Mark7CSharp.Common;
    using NUnit.Framework;

    [Binding]
    public sealed class LoginSteps : BaseSteps
    {
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

        [When(@"faço login com email e senha")]
        public void QuandoFacoLoginComEmailESenha(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                //loginPage.Logar(table., senha.ToString());
            }
            
        }

        [Then(@"devo ver a mensagem de alerta saida")]
        public void EntaoDevoVerAMensagemDeAlertaSaida(Table table)
        {
          //  Assert.True(loginPage.MensagemFalhaLogin().Text == mensagem);
        }

    }
}

namespace Mark7CSharp
{
    using Pages;
    using System;
    using Testes;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    //[Category("Login")]
    public class Login : BaseTest
    { 
        private IWebElement mensagem { get; set; }

        [Test]
        public void SenhaInvalida()
        {
            loginPage.Logar("ilton.io@ninja.com.br", "654321");
            Assert.True(loginPage.MensagemFalhaLogin().Text == "Incorrect password");
        }

        [Test]
        public void UsuarioInvalido()
        {
            loginPage.Logar("joao.das.neves@ninja.com.br", "123456");
            Assert.True(loginPage.MensagemFalhaLogin().Text == "User not found");
        }

        [Test]
        public void UsuarioNaoInformado()
        {
            loginPage.Logar("", "123456");
            Assert.True(loginPage.MensagemFalhaLogin().Text == "Email is required");
        }

        [Test]
        public void SenhaNaoInformada()
        {
            loginPage.Logar("ilton.io@ninja.com.br", "");
            Assert.True(loginPage.MensagemFalhaLogin().Text == "Password is required");
        }

        [Test]
        public void LoginComSucesso()
        {
            loginPage.Logar("ilton.io@ninja.com.br", "123456");
            Assert.True("Hello, ilton" == taskPage.BemVindo().Text);
        }
    }
}

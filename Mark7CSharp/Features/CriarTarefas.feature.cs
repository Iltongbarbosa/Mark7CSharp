﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Mark7CSharp.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Cadastrar tarefas")]
    [NUnit.Framework.CategoryAttribute("CadastroTarefas")]
    public partial class CadastrarTarefasFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CriarTarefas.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt"), "Cadastrar tarefas", "    Para que eu possa organizar minhas atividades\r\n    Sendo um usuário cadastrad" +
                    "o\r\n    Posso cadastrar novas tarefas", ProgrammingLanguage.CSharp, new string[] {
                        "CadastroTarefas"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 9
 #line 10
  testRunner.Given("que estou logado com \'ilton.io@ninja.com.br\' e \'pwd123\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Nova tarefa")]
        [NUnit.Framework.CategoryAttribute("NovaTarefa")]
        public virtual void NovaTarefa()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Nova tarefa", null, new string[] {
                        "NovaTarefa"});
#line 13
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Titulo",
                        "Data"});
            table1.AddRow(new string[] {
                        "Estudar Csharp e Specflow",
                        "31/12/2019"});
#line 14
        testRunner.Given("que eu tenho uma tarefa com os seguintes atributos:", ((string)(null)), table1, "Dado ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag"});
            table2.AddRow(new string[] {
                        "Csharp"});
            table2.AddRow(new string[] {
                        "Programação"});
            table2.AddRow(new string[] {
                        "Specflow"});
#line 17
        testRunner.And("eu quero taguear esta tarefa com:", ((string)(null)), table2, "E ");
#line 22
        testRunner.When("faço o cadastro dessa tarefa", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 23
        testRunner.Then("devo ver está tarefa com o status \'Em andamento\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line 24
        testRunner.And("devo ver somente 1 tarefa com o nome cadastrado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Tarefa não pode ser duplicada")]
        [NUnit.Framework.CategoryAttribute("TarefaDuplicada")]
        public virtual void TarefaNaoPodeSerDuplicada()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Tarefa não pode ser duplicada", null, new string[] {
                        "TarefaDuplicada"});
#line 27
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Titulo",
                        "Data"});
            table3.AddRow(new string[] {
                        "Tarefa duplicada",
                        "31/12/2019"});
#line 28
        testRunner.Given("que eu tenho uma tarefa com os seguintes atributos:", ((string)(null)), table3, "Dado ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag"});
            table4.AddRow(new string[] {
                        "Automação"});
            table4.AddRow(new string[] {
                        "Csharp"});
            table4.AddRow(new string[] {
                        "Programação"});
            table4.AddRow(new string[] {
                        "Specflow"});
#line 31
        testRunner.And("eu quero taguear esta tarefa com:", ((string)(null)), table4, "E ");
#line 37
        testRunner.But("eu já cadastrei esta tarefa e não tinha percebido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Mas ");
#line 38
        testRunner.When("faço o cadastro dessa tarefa", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 39
        testRunner.Then("devo ver a mensagem \'Tarefa duplicada.\' ao tentar cadastrar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line 40
        testRunner.And("devo ver somente 1 tarefa com o nome cadastrado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Valor mínimo")]
        [NUnit.Framework.CategoryAttribute("TituloMuitoCurto")]
        public virtual void ValorMinimo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Valor mínimo", null, new string[] {
                        "TituloMuitoCurto"});
#line 43
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Titulo",
                        "Data"});
            table5.AddRow(new string[] {
                        "Deu ruim",
                        "31/12/2019"});
#line 44
        testRunner.Given("que eu tenho uma tarefa com os seguintes atributos:", ((string)(null)), table5, "Dado ");
#line 47
        testRunner.When("faço o cadastro dessa tarefa", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 48
        testRunner.Then("devo ver a mensagem \'10 caracteres é o mínimo permitido.\' ao tentar cadastrar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion


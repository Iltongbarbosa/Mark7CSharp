#language: pt

@RemoverTarefas
Funcionalidade: Remover uma tarefa
    Para que eu possa deixar meu painel organizado
    Sendo um usuário que possui uma tarefa indesejada
    Posso excluir tarefas


	Contexto: Login
		Dado que faço login com 'ilton.io@ninja.com.br' e 'pwd123'

    @RemoverTarefa
    Cenario: Apagar uma tarefa
        Dado que tenho uma tarefa indesejada
        Quando eu solicito a exclusão desta tarefa
        E confirmo a ação de exclusão
        Então esta tarefa não deve ser exibida na lista

    @DesistirRemocao
    Cenario: Desistir da remoção
        Dado que tenho uma tarefa indesejada
        Quando eu solicito a exclusão desta tarefa
        Mas eu cancelo esta ação
        Então esta tarefa permanece na lista
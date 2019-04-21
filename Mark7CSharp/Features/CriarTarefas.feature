#language: pt

@CadastroTarefas
Funcionalidade: Cadastrar tarefas
    Para que eu possa organizar minhas atividades
    Sendo um usuário cadastrado
    Posso cadastrar novas tarefas

	Contexto: Login
		Dado que estou logado com 'ilton.io@ninja.com.br' e 'pwd123'

    @NovaTarefa
    Cenario: Nova tarefa
        Dado que eu tenho uma tarefa com os seguintes atributos:
            | Titulo                    | Data       |
            | Estudar Csharp e Specflow | 31/12/2019 |
        E eu quero taguear esta tarefa com:
            | Tag         |
            | Csharp      |
            | Programação |
            | Specflow    |
        Quando faço o cadastro dessa tarefa
        Então devo ver está tarefa com o status 'Em andamento'
        E devo ver somente 1 tarefa com o nome cadastrado

    @TarefaDuplicada
    Cenario: Tarefa não pode ser duplicada
        Dado que eu tenho uma tarefa com os seguintes atributos:
            | Titulo           | Data       |
            | Tarefa duplicada | 31/12/2019 |
        E eu quero taguear esta tarefa com:
            | Tag         |
            | Automação   |
            | Csharp      |
            | Programação |
            | Specflow    |
        Mas eu já cadastrei esta tarefa e não tinha percebido
        Quando faço o cadastro dessa tarefa
        Então devo ver a mensagem 'Tarefa duplicada.' ao tentar cadastrar
        E devo ver somente 1 tarefa com o nome cadastrado

    @TituloMuitoCurto
    Cenario: Valor mínimo
        Dado que eu tenho uma tarefa com os seguintes atributos:
            | Titulo   | Data       |
            | Deu ruim | 31/12/2019 |
        Quando faço o cadastro dessa tarefa
        Então devo ver a mensagem '10 caracteres é o mínimo permitido.' ao tentar cadastrar
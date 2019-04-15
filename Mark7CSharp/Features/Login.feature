#language: pt

Funcionalidade: Login
    Para que somente eu possa ver as minhas tarefas
    Sendo um usuário cadastrado
    Posso logar no sistema
    
    @login
    Cenario: Login do usuário
        Quando faço login com 'ilton.io@ninja.com.br ' e '123456'
        Então sou redirecionado para o painel de tarefas com a mensagem 'Hello, ilton'

    @loginFalha
    Esquema do Cenário: Tentativa de logar
        Quando faço login com '<email>' e '<senha>'
        Então devo ver a mensagem de alerta '<saida>'
		Exemplos:
        | email                               | senha   | saida                |
        | ilton.io@ninja.com.br               | 654321  | Incorrect password   |
        | joao.das.neves@dancadascadeiras.org | xpto123 | User not found       |
        | ilton&qaninja.io                    | 123456  | User not found       |
        |                                     | xpto123 | Email is required    |
        | ilton.io@ninja.com.br               |         | Password is required |
        |                                     |         | Email is required    |
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
        Quando faço login com email e senha
		 | email                               | senha   |
		 | ilton.io@ninja.com.br               | 654321  |
		 | joao.das.neves@dancadascadeiras.org | xpto123 |
		 | ilton&qaninja.io                    | 123456  |
		 |                                     | xpto123 |
		 | ilton.io@ninja.com.br               |         |
		 |                                     |         |
		Então devo ver a mensagem de alerta saida
		| saida                |
		| Incorrect password   |
		| User not found       |
		| User not found       |
		| Email is required    |
		| Password is required |
		| Email is required    |
#language: pt

@Login
Funcionalidade: Login
    Para que somente eu possa ver as minhas tarefas
    Sendo um usuário cadastrado
    Posso logar no sistema
    
	@loginComSucesso
	Cenario: Login com sucesso
			Quando faço login com 'ilton.io@ninja.com.br' e 'pwd123'
			Então sou redirecionado para o painel de tarefas com a mensagem 'Hello, ilton'
	
	@LiginInvalido
    Esquema do Cenário: Tentativa de logar
        Quando faço login com <email> e <senha>
        Então devo ver a mensagem de alerta <saida>
        Exemplos: 
        | email                                 | senha    | saida                  |
        | 'ilton.io@ninja.com.br'               | 'pwd321' | 'Incorrect password'   |
        | 'joao.das.neves@dancadascadeiras.org' | 'pwd123' | 'User not found'       |
        | 'ilton&qaninja.io'                    | 'pwd123' | 'Email is required'    |
        | ''                                    | 'pwd123' | 'Email is required'    |
        | 'ilton.io@ninja.com.br'               | ''       | 'Password is required' |
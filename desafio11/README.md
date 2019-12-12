# Segurança de acesso para Web API com JSON Web Token

Uma das formas de prover segurança nas APIs e que vamos utilizar é através do uso de **tokens de acesso**, mais especificamente o [JSON Web Token](https://jwt.io/). Esse tipo de abordagem de segurança é um tipo muito eficiente porque permite separar o serviço que gera o **token** do serviço da API. Dessa forma, depois de gerado o token, a API não precisa saber a senha do usuário que autenticou, ela pode receber informações através de **claims** que indicam, por exemplo, nome de roles e outras informações do usuário que autenticou de forma a dar ou não acesso a ele em um recurso.

Nós vamos chamar o serviço de segurança de **Provedor de Identidade**. O provedor irá utilizar 5 elementos de segurança durante a autenticação. Um `client_id` e um `client_secret` que identifica o cliente, um `username` e uma `password` que identifica um usuário e um `scope` que identifica o conjunto de recursos que quer ter acesso. 

De forma simplificada, o fluxo da segurança irá funcionar da seguinte forma:
- O provedor inicialmente recebe a configuração do `client_id`, do `client_secret` e dos `scopes` da API. Isso pode ser de várias formas, normalmente fica em um banco de dados. No nosso caso essa configuração será direta no código
- O programa cliente, que recebeu o `client_id` e o `client_secret` faz uma chamada passando esses dados, o `username`, a `password` e o `scope` para o provedor
- O provedor autentica as informações recebidas, gera um **token**, assinado e o retorna para o programa cliente
- O programa cliente usa esse **token** em um `header` de uma requisição `HTTP` quando faz a chamada para a API  
- A aplicação, antes de executar a API, valida a identidade desse **token** checando a assinatura, descobre os dados relevantes do usuário que estão dentro do **token** que irão definir um perfil de autorização, verifica se o controller/método chamado tem a configuração de autorização e checa se está OK
- Se estiver autorizado, executa a API, caso contrário retorna um status `Forbidden`
- Se a chamada for feita para um endpoint segura sem informar o **token** a aplicação retornar um status `Unauthorized`

Neste desafio você receberá um projeto pré-configurado com as entidades do EF, os serviços de manipulação de dados e os controladores prontos para acesso aos dados do banco de dados `Codenation`. O projeto também estará configurado com o **Provedor de Identidade**, que para esse desafio usaremos o `IdentityServer4` que é um pacote open source. Você deverá configurar os controladores para receber os atributos de segurança conforme as regras e também deverá construir o código do serviço de perfis do servidor de identidade. Esse serviço é o responsável por ler as informações dos usuários da tabela `user` do banco de dados (através do modelo `User` do EF), validando a senha e retornando para o serviço do provedor que irá gerar o **token**.

Você também receberá boa parte do projeto de testes pronto para continuar com as checagens necessárias. Diferente de outros tipos de testes unitários, nesse desafio os testes irão chamar as rodas emulando o `web service` através de um servidor de testes chamado `TestServer`. Veja os links do desafio para mais informações sobre o `TestServer`.

## Regras para a configuração da segurança

- O `client_id` estará definido como `codenation.api_client` e o `client_secret` como `codenation.api_secret`. O `scope` estará definido como `codenation`
- A configuração do provedor de identidade incluí duas `Claims`: `Email` e `Role`. Como a base de dados `Codenation` não possuí uma entidade para definir papéis de segurança de usuário, deve-se assumir o papel de `User` para todos os usuários e papel `Admin` apenas o usuário com e-mail `tegglestone9@blog.com`
- O `username` para autenticação será a propriedade `Email` do modelo `User` e a `password` será a propriedade `Password`
- A segurança deve ser feita utilizando o atributo `Authorize` apenas na classe do controlador. Não será feita configuração nos métodos
- Todos os controladores, **exceto** o controlador `ChallengeController`, receberão configuração para autorizar o acesso 
- O controlador `UserController` receberá a configuração de segurança com uma `policy` de **Admin**, ou seja apenas o **token** gerado pelo usuário com role `Admin` terá acesso as rotas desse controlador. Para todos os **tokens** gerados para outros usuários deverá retornar um status `Forbidden`

### Classe `PasswordValidatorService`

- Concluir a implementação da classe porque da forma como está ela sempre irá retornar uma autenticação inválida. Essa classe é responsável por verificar se a senha do usuário é válida. O e-mail do usuário será passado na propriedade `UserName` do contexto no método `ValidateAsync` e a senha é passada na propriedade `Password` do contexto.
- O método `ValidateAsync` deve retonar um `GrantValidationResult` passando como `subject` o `Id` do usuário, o `authenticationMethod` como `custom` e em `claims` a lista de **Claims** do usuário. Para a lista de claims pode ser usado o método estático já definido em `UserProfileService`.

### Classe `UserProfileService`

- Concluir a implementação do método `GetProfileDataAsync` e do método `GetUserClaims`. Esse método deve buscar as informações do usuário que está sendo passado no contexto e retornar as **Claims**. As claims necessárias estão definidas no método `GetUserClaims`. Siga as regras de configuração para terminar a construção desses métodos. O método `GetUserClaims` é utilizado também pela classe `PasswordValidatorService`. Esses dois serviços são responsáveis por validar e retornar as informações do usuário que estarão presentes no **token**.

### Classe `Startup`

- Concluir o código para inserir as **polices** no método na configuração `AddAuthorization` dentro do método `ConfigureServices`. Essa configuração permite usar a policy no atributo `Authorize` dos controladores para autorizar o acesso ou não de acordo com a regra programada na policy.   


Neste desafio você aprenderá:

* Classes e objetos
* Interfaces
* IdentityServer4
* Segurança de APIs com JSON Web Token
* Autorização de Rotas
* Testes de Integração

### Informações adicionais

Para rodar o projeto Web API, utilize o comando `dotnet run -p Source`. O serviço ficará disponível na URL [`http://localhost:5000`](http://localhost:5000). A chamada para os endpoints pode ser feita utilizando um programa externo como o popular [Postman](https://www.getpostman.com/) ou um plugin de navegador open source como o [RESTer](https://github.com/frigus02/RESTer). 

Para enviar uma requisição com o **token** você precisa adicionar um `Header` do tipo `Authorization` e com o valor `Bearer` seguido de um espaço e o **token** gerado. Pode usar o [site do JWT](https://jwt.io/) para colocar o **token** gerado e ver o seu conteúdo.

Esse desafio requer que o banco de dados esteja instalado no **LocalDB**. Para isso certifique-se que já instalou o servidor através dos links do desafio e o serviço do banco de dados está iniciado. Após isso será necessário restaurar o banco de dados fornecido com o desafio. Na pasta do projeto há um arquivo de back-up chamado `Codenation.bak`. Para restaurar esse banco no servidor local do **LocalDB** pode executar o arquivo `restore-database.bat`. Caso queira rodar diretamente o comando com o `sqlcmd`, pode rodar o comando `sqlcmd -S "(localdb)\mssqllocaldb" -Q "RESTORE DATABASE Codenation FROM DISK='Codenation.bak'"` estando na pasta do arquivo `Codenation.bak`.

Uma informação importante a saber é que normalmente o provedor de identidade não é um serviço que roda em conjunto com a aplicação que fornece a API. Em um ambiente de produção esse servidor fica em um endereço diferente e tem um banco de dados para guardar as configurações de cada cliente e usuário, muitas vezes com integração a serviços de segurança como LDAP, porque ele irá servir a várias aplicações. No desafio ele foi programado em conjunto apenas para facilitar o aprendizado.

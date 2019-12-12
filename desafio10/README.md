# Manipulação de dados com C# através de Web API

Neste desafio você receberá um projeto pré-configurado com as entidades do EF e os serviços de manipulação de dados prontos. Receberá também as classes dos controladores para serem implementadas de forma a responder aos endpoints definidos. Você deverá implementar o código respeitando as regras definidas.

Você irá notar que os serviços respondem com instâncias de classes `DTO` e não com as instâncias das próprias classes das entidades de dados. Para fazer esse mapeamento você pode escrever um código de conversão Modelo-DTO e DTO-Modelo ou pode utilizar um componente chamado `AutoMapper` que já está presente e configurado no projeto. Mais informações sobre como usar o **AutoMapper** você pode encontrar nos links do desafio.

Você também terá que registrar as interfaces de serviço no mecanismo de injeção de dependência do .NET Core caso contrário as chamadas para os controladores irão falhar. A classe `CodenationContext`, o `AutoMapper` e a interface `IUserService` já estão registradas. 

## Regras para a construção dos controladores

- As classes estão presentes na pasta `Controllers` do projeto `Source` e devem receber a implementação do código
- A classe de `DBContext` chamada `CodenationContext` já está pronta e registrada
- Os serviços usados pelos controladores também estão prontos na pasta `Services` e apenas o `IUserService` está registrado
- O controlador `UserController` já está parcialmente implementado para que você possa usar de exemplo
- As rotas tem acesso via `GET`, caso não for especificado
- Todas as requisições respondem com **status `200`**, caso não for especificado

### Classe `UserController` 

- Deve utilizar o serviço registrado para `IUserService`
- Rota `api/user`: essa rota deve ter dois parâmetros opcionais. Quando não informados ou quando ambos informados, deve retornar **status `204`**
  - parâmetro `accelerationName`: deve apontar para o método `FindByAccelerationName` e retornar uma lista de `UserDTO`
  - parâmetro `companyId`: deve apontar para o método `FindByCompanyId` e retornar uma lista de `UserDTO`
- Rota `api/user/{id}`: deve apontar para o método `FindById` e retornar um `UserDTO`
- Rota `api/user` com `POST`: deve receber um `UserDTO`, apontar para o método `Save` e retornar um `UserDTO`

### Classe `CompanyController`

- Deve utilizar o serviço registrado para `ICompanyService`
- Rota `api/company/{id}`: deve apontar para o método `FindById` e retornar um `CompanyDTO`
- Rota `api/company`: essa rota deve ter dois parâmetros opcionais. Quando não informados ou quando ambos informados, deve retornar **status `204`**
  - parâmetro `accelerationId`: deve apontar para o método `FindByAccelerationId`e retornar uma lista de `CompanyDTO`
  - parâmetro `userId`: deve apontar para o método `FindByUserId` e retornar uma lista de `CompanyDTO`
- Rota `api/company` com `POST`: deve receber um `CompanyDTO`, apontar para o método `Save` e retornar um `CompanyDTO`

### Classe `ChallengeController`

- Deve utilizar o serviço registrado para `IChallengeService`
- Rota `api/challenge`: essa rota deve ter dois parâmetros opcionais. Quando os dois não forem informados, deve retornar **status `204`**
  - parâmetros `accelerationId` e `userId`: deve apontar para o método `FindByAccelerationIdAndUserId` e retornar uma lista de `ChallengeDTO`
- Rota `api/challenge` com `POST`: deve receber um `ChallengeDTO`, apontar para o método `Save` e retornar um `ChallengeDTO`

### Classe `AccelerationController`

- Deve utilizar o serviço registrado para `IAccelerationService`
- Rota `api/acceleration/{id}`: deve apontar para o método `FindById` e retornar um `AccelerationDTO`
- Rota `api/acceleration`: essa rota deve ter um parâmetro opcional. Quando não informado, deve retornar **status `204`**
  - parâmetro `companyId`: deve apontar para o método `FindByCompanyId` e retornar uma lista de `AccelerationDTO`
- Rota `api/acceleration` com `POST`: deve receber um `AccelerationDTO`, apontar para o método `Save` e retornar um `AccelerationDTO`

### Classe `CandidateController`

- Deve utilizar o serviço registrado para `ICandidateService`
- Rota `api/candidate/{userId}/{accelerationId}/{companyId}`: deve apontar para o método `FindById` e retornar um `CandidateDTO`
- Rota `api/candidate`: essa rota deve ter dois parâmetros opcionais. Quando não informados ou quando ambos informados, deve retornar **status `204`**
  - parâmetro `companyId`: deve apontar para o método `FindByCompanyId` e retornar uma lista de `CandidateDTO`
  - parâmetro `accelerationId`: deve apontar para o método `FindByAccelerationId` e retornar uma lista de `CandidateDTO`
- Rota `api/candidate` com `POST`: deve receber um `CandidateDTO`, apontar para o método `Save` e retornar um `CandidateDTO`

### Classe `SubmissionController`

- Deve utilizar o serviço registrado para `ISubmissionService`
- Rota `api/submission/higherScore`: essa rota deve ter um parâmetro e caso não seja fornecido deve retornar **status `204`**
  - parâmetro `challengeId`: deve apontar para o método `FindHigherScoreByChallengeId` e retornar o valor do maior score 
- Rota `api/submission`: essa rota deve ter dois parâmetros opcionais. Quando os dois não forem informados, deve retornar **status `204`**
  - parâmetros `challengeId` e `accelerationId`: deve apontar para o método `FindByChallengeIdAndAccelerationId` e retornar uma lista de `SubmissionDTO`
- Rota `api/submission` com `POST`: deve receber um `SubmissionDTO`, apontar para o método `Save` e retornar um `SubmissionDTO`

Neste desafio você aprenderá:

* Classes e objetos
* Interfaces
* Configurar Injeção de Dependências
* Controladores e Rotas
* Mapeamento DTO-Modelo-DTO

### Informações adicionais

Para executar os testes, você pode adotar a abordagem de construir **Mocks** para os serviços de forma a testar apenas a camada do controlador porque a princípio você já testou a camada de dados quando executou os testes dos serviços. É fornecida uma classe chamada `Fakes` com uma implementação básica que faz a leitura de dados de arquivos e uma implementação inicial de um **mock** para a interface de serviço `IUserService`. Você pode completar a implementação e usar a mesma classe para dar continuidade nos testes. Nos links do desafio você encontrará material para entender como usar o pacote `Moq` para fazer os **mocks**.

Para rodar o projeto Web API, utilize o comando `dotnet run -p Source`. O serviço ficará disponível na URL [`http://localhost:5000`](http://localhost:5000). A chamada para os endpoints pode ser feita utilizando um programa externo como o popular [Postman](https://www.getpostman.com/) ou um plugin de navegador open source como o [RESTer](https://github.com/frigus02/RESTer). Para esse cenário é fornecido um banco de dados pronto com dados de teste.

Caso execute e queira testar os endpoints, também é fornecido o arquivo `data.sql` com comandos SQL para carregar os dados nas tabelas do banco de dados `Codenation`. Para gerar o banco de dados, estando no terminal na pasta do projeto `Source` execute os comandos `dotnet ef migrations add Initial` para gerar as classes do EF Core Migrations na pasta `Migrations` e o comando `dotnet ef database update` para rodar a migração e criar o banco de dados. Para acessar o banco de dados você precisa de alguma ferramenta como o Visual Studio, o SQL Management Studio ou outra que possa conectar no banco mssql LocalDB. Mais informações sobre o banco **LocalDB** e sobre o **EF Core Migrations** você encontrará nos links do desafio.

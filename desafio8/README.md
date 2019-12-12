# Manipulação de dados através de serviços

O Entity Framework Core (EF) é a tecnologia que faz o papel de ORM na plataforma .Net. Através das classes `DBContext` e `DbSet` você terá métodos para ler e gravar os dados das entidades. Esse desafio contém um projeto pré-configurado com a classe de contexto `CodenationContext` ligada a um banco de dados SQL Server LocalDB. O projeto também conta com a implementação das classes de entidades de dados de acordo com [essa imagem do modelo ER](https://codenation-challenges.s3-us-west-1.amazonaws.com/java-9/codenation-sample.png). Para concluir esse desafio você irá construir as classes de serviço que acessam o repositório do EF para executar a manipulação de dados que vão recuperar e gravar os dados das entidades. 

Serão fornecidas as interfaces a serem implementadas nos serviço para que você faça a implementação do métodos de acordo com as regras abaixo.

## Regras para a construção das classes de serviço

- As classes estão presentes na pasta `Services` do projeto `Source` e devem receber a implementação do código.
- A classe de `DBContext` chamada `CodenationContext` já está registrada para ser injetada nos serviços através do mecanismo de injeção de dependências do .Net Core.

### Interface `IUserService`

- Método `FindById`: deve retornar **um usuário** a partir do **id do usuário**
- Método `FindByAccelerationName`: deve retornar **uma lista de usuários** a partir do **nome da aceleração**
- Método `FindByCompanyId`: deve retornar **uma lista de usuários** a relacionado com a empresa pelo **id da empresa**
- Método `Save`: deve retornar **um usuário** após salvar os dados. Caso o `Id` seja zero, fará a inserção do usuário, caso contrário fará a atualização dos dados do usuário com o `Id` informado

### Interface `ICompanyService`

- Método `FindById`: deve retornar **uma empresa** a partir do **id da empresa**
- Método `FindByAccelerationId`: deve retornar **uma lista de empresas** a partir do **id da aceleração**
- Método `FindByUserId`: deve retornar **uma lista de empresas** a partir do **id do usuário**
- Método `Save`: deve retorna **uma empresa** após salvar os dados. Caso o `Id` da instância não seja fornecido, fará a inserção da empresa, caso contrário fará a atualização dos dados da empresa com o `Id` informado

### Interface `IChallengeService`

- Método `FindByAccelerationIdAndUserId`: deve retornar **uma lista de desafios** a partir do **id da aceleração** e do **id do usuário**
- Método `Save`: deve retornar **um desafio** após salvar os dados. Caso o `Id` seja zero, fará a inserção da aceleração, caso contrário fará a atualização dos dados da aceleração com o `Id` fornecido.

### Interface `IAccelerationService`

- Método `FindById`: deve retornar **uma aceleração** a partir do **id da aceleração**
- Método `FindByCompanyId`: deve retornar **uma lista de acelerações** a partir do **id da empresa**
- Método `Save`: deve retornar **uma aceleração** depois de salvar os dados. Caso o `Id` seja zero, fará a inserção da aceleração, caso contrário fará a atualização dos dados da aceleração com o `Id` informado

### Interface `ICandidateService`

- Método `FindById`: deve retornar **um candidato** a partir do **id do usuário**, do **id da aceleração** e do **id da empresa**
- Método `FindByCompanyId`: deve retornar **uma lista candidatos** a partir do **id da empresa**
- Método `FindByAccelerationId`: deve retornar **uma lista de candidatos** a partir do **id da aceleração**
- Método `Save`: deve retornar **um candidato** após salvar os dados. Caso a tupla `UserId`, `AccelartionId` e `CompanyId` não exista, fará a inserção do candidato, caso contrário fará a atualização dos dados do candidato

### Interface `ISubmissionService`

- Método `FindHigherScoreByChallengeId`: deve retornar o valor do maior score a partir do **id do desafio**
- Método `FindByChallengeIdAndAccelerationId`: deve retornar **uma lista de submissões** a partir do **id do desafio** e do **id da aceleração**
- Método `Save`: deve retornar **uma submissão** após salvar os dados. Caso a tupla `UserId` e `ChallengeId` não exista, fará a inserção da submissão, caso contrário fará a atualização dos dados da submissão

Neste desafio você aprenderá:

* Classes e objetos
* Interfaces
* Ler e escrever dados em banco de dados

### Informações adicionais

Para executar os testes, você pode adotar algumas abordagens:

- Fazer o **mock** das classes de repositório. Esse modo é utilizado na maioria dos cenários de testes, porém em um cenário que envolvem várias entidades, fica complexo. Para usar essa técnica, pode utilizar alguns pacotes como o `Moq`, por exemplo. Nas versões atuais do EF é possível fazer o **mock** do `DBContext`, então você não precisa construir as classes de repositório, se quiser. 
- Criar o banco de dados fisicamente e preencher com os dados de teste. Esse modo é o que vai testar o código mais próximo do real, porém requer um mecanismo que possa limpar o banco de dados e preencher as tabelas a cada execução de testes. O cuidado nesse caso é que em um banco real, ao apagar registros e inserir novamente os IDs gerados automaticamente normalmente mudam de uma execução para outra e isso pode ser um problema.
- Criar um banco de dados em memória. No EF você pode fazer isso com um banco SQL-inMemory ou um banco SQLite-inMemory. O banco SQLite-inMemory simula o banco relacional de forma mais próxima de um banco real e o SQL-inMemory não implementa, porém para a maioria dos testes, a faltas de todas as funcionalidades de um banco relacional não é um problema. A desvantagem nesse caso é ter algum tipo de cenário onde é necessário um volume grande de dados e carregar tudo na memória pode não ser uma boa estratégia.

Junto ao projeto de teste é fornecida uma classe chamada `FakeContext` que pode ajudar na tarefa de teste com banco In-Memory. Você encontrará a documentação sobre como usar um banco In-Memory para testes nos links do desafio.

Caso utilize um banco físico para testes você pode criar o banco com as ferramentas de migração do próprio EF. Nesse caso você pode perceber que os tipos de dados entre o banco criado e o modelo ER fornecido pode estar diferente, mas isso é esperado.





# ORM .Net

O ORM padrão do .NET Core chama Entity Framework Core (EF). Existem basicamente 4 modos de trabalhar com o EF:

- O modo **model-first**, em que o programador desenha um modelo EDM com as ferramentas do Visual Studio e depois gera o banco de dados e as classes. 
- O modo **database-first** em que o banco de dados já existe e o programador utiliza o Visual Studio para gerar o modelo EDM a partir do banco. 
- O modo **code-first** em que o programador desenha as classes diretamente via código e depois gera o banco de dados.
- O modo **code-first from existing database** em que o programador usa o Visual Studio para gerar o código das classes diretamente sem gerar o modelo EDM. 

Cada modo tem suas vantagens e desvantagens. Nesse desafio, embora existe um banco de dados já pronto, vamos utilizá-lo apenas como referência e utilizar o modo **code-first** que é o modo mais flexível de todos. 

O desafio contém um projeto pré-configurado para usar o Entity Framework Core com banco de dados SQL Server LocalDB.

[Nessa imagem de um modelo ER](https://codenation-challenges.s3-us-west-1.amazonaws.com/java-9/codenation-sample.png) você encontrará um Modelo Entidade-Relacionamento de um banco de dados utilizado pela Codenation que servirá de referência para construir as classes. Para concluir esse desafio você irá criar as classes que representam cada entidade e cada relacionamento do Modelo ER.

## Regras para a construção das classes

- As classes devem ser construídas na pasta `Models` do projeto `Source`.
- A classe de `DBContext` chamada `CodenationContext` já é fornecida junto ao projeto e deve ser mantida porque será utilizadas para os testes.
- É fornecida uma classe de testes básica de exemplo que usa o `CodenationContext` para investigar os metadados gerados no modelo. Você deve complementar os testes criando novas classes de testes baseado nesse exemplo.
- O modelo ER não apresenta a informação se os campos aceitam ou não valores nulos e você deve admitir que todos os campos não aceitam valores nulos.
- Para a tradução dos tipos de dado entre o banco e as classes, utilize:
  - `timestamp`: `DateTime`
  - `varchar`: `string`
  - `int`: `int`
  - `float`: `decimal` (tamanho 9,2)

- O modelo ER apresenta as chaves estrangeiras porém não indica quais navegações `1..*` devem ser configuradas. Dessa forma admita que todas chaves estrangeiras requerem uma navegações `1..*` na classe que representa a entidade pai. Abaixo a lista das navegações que serão checadas:
  - Entidade `User`: navegação para `Candidate` e `Submission`
  - Entidade `Acceleration`: navegação para `Candidate`
  - Entidade `Company`: navegação para `Candidate`
  - Entidade `Challenge`: navegação para `Acceleration` e `Submission`

### Informações adicionais

No Entity Framework Core existem dois modos para fazer o mapeamento entre as classes e o banco de dados. Através de atributos que são chamados `Data Annotations` ou através do `Model Builder` utilizando `Fluent API`. A primeira forma é aplicada diretamente na classe e a segunda forma é feita ou através de classes de configuração ou através de código diretamente no método `OnModelCreating` do `DBContext`. Algumas configurações no entanto, como a definição de chave primária composta, por exemplo, só são possíveis com o `Fluent API`, por isso você pode adotar uma forma mista de configuração, se preferir. 

Embora o modelo final irá representar o banco de dados e você pode utilizar uma característica do EF chamada `Migrations` para criar o banco de dados, para esse desafio não é preciso fazer isso e nem existir o banco de dados físico, basta que as classes reflitam o Modelo ER.

## Avaliação

A avaliação irá checar:

- Nome de tabelas e colunas
- Tipos das colunas
- Colunas não nulas
- Tamanho das colunas
- Relacionamento entre tabelas (chave estrangeiras)
- Navegações
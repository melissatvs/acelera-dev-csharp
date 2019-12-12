# Gerador de frases do Monty Python

Monty Python foi um dos grupos de comediantes mais influentes e reverenciados da história da TV. Vamos criar uma API para gerar frases aleatórias coletadas dos episódios da trupe, de acordo com nosso ator favorito.

Junto ao projeto é fornecido um banco de dados SQLite com uma tabela com os dados das frases já inseridos.

Utilizando C# você deverá implementar um Web Service de forma a permitir a consulta de frases aleatórias ou frases específicas de um ator. 

A resposta a chamada das URLs dever ser um JSON com os atributos `id`, `actor` e `quote`. Exemplo:

```json
{ 
	"id": 13736,
	"actor": "Graham Chapman",
	"quote": "Come on Sidney."
}
```

>Yes, and much less formal!

A estrutura do projeto Web API já está pronta e as classes de modelo também são fornecidas. O desafio é implementar o código nas classes `QuoteController`, `QuoteService` e `RandomService`. Os testes devem ser escritos nas classes de testes correspondentes.

Para rodar o web service, utilize o comando `dotnet run -p source`. O serviço ficará disponível na URL [`http://localhost:5000`](http://localhost:5000). A chamada para os endpoints pode ser feita utilizando um programa externo como o popular [Postman](https://www.getpostman.com/) ou um plugin de navegador open source como o [RESTer](https://github.com/frigus02/RESTer)


## Definição das URLs

### `api/quote`

Método: `GET`

Retorna uma frase aleatória de qualquer ator.

### `api/quote/{actor}`

Método: `GET`

Retorna uma frase aleatória do ator passado como parâmetro.

## Estrutura do Banco de Dados

Tabela: `scripts`

Campo             | Tipo      | Descrição
----------------- | ----------|-----------
id                | Long      | Id do registro - Chave Primária
episode           | Int       | Número do episódio
episode_name      | String    | Nome do episódio
segment           | String    | Nome da sequência
type              | String    | Tipo de Frase
actor             | String    | Nome do ator
character         | String    | Nome do personagem
detail            | String    | Frase
record_date       | DateTime  | Data da gravação do episódio
series            | String    | Número da série
transmission_date | DateTime  | Data da exibição do episódio

__Os tipos de dados se referem ao tipo na classe do objeto e não no banco de dados__

## Tópicos

Neste desafio você aprenderá:

* Classes e objetos
* Criar uma aplicação Web API
* Testa uma aplicação Web API
* Ler dados de banco de dados
* Entity Framework Core

## Requisitos
​
Para este desafio você precisará :

- .NET Core 2.0+
- Visual Studio ou Visual Studio Code

Para instalar o .NET Core e o Visual Studio, confira os links na seção de conteúdo.
O Visual Studio Code é uma opção mais leve para programar, porém o Visual Studio 2019 é mais completo.

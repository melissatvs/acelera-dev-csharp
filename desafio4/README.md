# Backend para gerenciar times de futebol

Você é responsável por construir o backend de um novo gerenciador de times de futebol. Após fecharem o escopo do projeto, você e sua equipe definiram a `interface` que o software deve implementar. A interface é a seguinte:

``` csharp

    public interface IManageSoccerTeams 
	{
		void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor);

		void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary);

		void SetCaptain(long playerId);

		long GetTeamCaptain(long teamId);

		string GetPlayerName(long playerId);

		string GetTeamName(long teamId);

		long GetHigherSalaryPlayer(long teamId);

		decimal GetPlayerSalary(long playerId);

		List<long> GetTeamPlayers(long teamId);

		long GetBestTeamPlayer(long teamId);

		long GetOlderTeamPlayer(long teamId);

		List<long> GetTeams();

		List<long> GetTopPlayers(int top);

		string GetVisitorShirtColor(long teamId, long visitorTeamId);
	}
```

Os dados devem ficar armazenados na memória.

## Requisitos de Sistema

- Parâmetros com `*` são obrigatórios. Um parâmetro obrigatório significa que ele deve ser informado na chamada do método. 
- Os parâmetros, com exceção de identificadores, são sempre íntegros e farão sentido.

### IncluirTime

Realiza a inclusão de um novo time.

- `long` `id`* Identificador do time
- `string` `name`* Nome do Time
- `DateTime` `createDate`* Data de criação do time
- `string` `mainShirtColor`* Cor do uniforme principal do time
- `string` `secondaryShirtColor`* Cor do uniforme secundário do time

**Exceções**

- Caso o `id` já exista, retornar `Codenation.Challenge.Exceptions.UniqueIdentifierException`

### IncluirJogador

Realiza a inclusão de um novo jogador.

- `long` `id`* Identificador do Jogador
- `long` `teamId`* Identificador do time
- `string` `name`* Nome do Jogador
- `DateTime` `birthDate`* Data de nascimento do Jogador
- `int` `skillLevel`* Nível de habilidade do jogador (0 a 100)
- `decimal` `salary`* Salário do jogador

**Exceções**

- Caso o `id` já exista, retornar `Codenation.Challenge.Exceptions.UniqueIdentifierException`
- Caso o time informado não exista, retornar `Codenation.Challenge.Exceptions.TeamNotFoundException`

### DefinirCapitao

Define um jogador como capitão do seu time. Um time deve ter apenas um capitão, por tanto o capitão anterior voltará a ser apenas jogador.

- `long` `playerId`* Identificador do jogador.

**Exceções**

- Caso o jogador informado não exista, retornar `Codenation.Challenge.Exceptions.PlayerNotFoundException`

### BuscarCapitaoDoTime

Mostra o `id` do capitão do time.

- `long` `teamId`* Identificador do Time

**Exceções**

- Caso o time informado não exista, retornar `Codenation.Challenge.Exceptions.TeamNotFoundException`
- Caso o time informado não tenha um capitão, retornar `Codenation.Challenge.Exceptions.CaptainNotFoundException`

### BuscarNomeJogador

Retorna o `name` do jogador.

- `long` `playerId`* Identificador do jogador

**Exceções**

- Caso o jogador informado não exista, retornar `Codenation.Challenge.Exceptions.PlayerNotFoundException`

### BuscarNomeTime

Retorna o `name` do time.

- `long` `teamId`* Identificador do Time

**Exceções**

- Caso o time informado não exista, retornar `Codenation.Challenge.Exceptions.TeamNotFoundException`

### BuscarJogadoresDoTime

Retorna a lista com o `id` de todos os jogadores do time, ordenada pelo `id`.

- `long` `teamId`* Identificador do Time

**Exceções**

- Caso o time informado não exista, retornar `Codenation.Challenge.Exceptions.TeamNotFoundException`

### BuscarMelhorJogadorDoTime

Retorna o `id` do melhor jogador do time. Utilizar o menor `id` como critério de desempate.

- `long` `teamId`* Identificador do time.

**Exceções**

- Caso o time informado não exista, retornar `Codenation.Challenge.Exceptions.TeamNotFoundException`

### BuscarJogadorMaisVelho

Retorna o `id` do jogador mais velho do time. Usar o menor `id` como critério de desempate.

- `long` `teamId` * Identificador do time

**Exceções**

- Caso o time informado não exista, retornar `Codenation.Challenge.Exceptions.TeamNotFoundException`

### BuscarTimes

Retorna uma lista com o `id` de todos os times cadastrado, ordenada pelo `id`.
Retornar uma lista vazia caso não encontre times cadastrados.

### BuscarJogadorMaiorSalario

Retorna o `id` do jogador com maior salário do time. Usar o menor `id` como critério de desempate.

- `long` `teamId`* Identificador do time.

**Exceções**

- Caso o time informado não exista, retornar `Codenation.Challenge.Exceptions.TeamNotFoundException`

### BuscarSalarioDoJogador

Retorna o `salário` do jogador.

- `long` `playerId`* Identificador do jogador

**Exceções**

- Caso o jogador informado não exista, retornar `Codenation.Challenge.Exceptions.PlayerNotFoundException`

### BuscarTopJogadores

Retorna uma lista com o `id` dos `top` melhores jogadores, utilizar o menor `id` como critério de desempate.

- `int` `top`* Quantidade de jogares na lista

**Exceções**

- Caso não exista nenhum jogador cadastrado, retornar uma lista vazia.

### BuscarCorCamisaTimeDeFora

Retorna a cor da camisa do time adversário. 
Caso a `mainShirtColor` do time da casa seja **igual** a `mainShirtColor` do time de fora, retornar `secondaryShirtColor` do time de fora.
Caso a `mainShirtColor` do time da casa seja **diferente** da `mainShirtColor` do time de fora, retornar `mainShirtColor` do time de fora.

- `long` `teamId`* Identificador do time da casa
- `long` `visitorTeamId`* Identificador do time de fora

**Exceções**

- Caso o time da casa ou o time de fora informado não existam, retornar `Codenation.Challenge.Exceptions.TeamNotFoundException`

## Tópicos

Neste desafio você aprenderá:

- Variáveis e métodos
- Operadores matemáticos
- Controle de fluxo
- Listas
- Métodos de ordenação
- Tratamento de exceções

## Requisitos
​
​Para este desafio você precisará :

- .NET Core 2.0+
- Visual Studio ou Visual Studio Code

Para instalar o .NET Core e o Visual Studio, confira os links na seção de conteúdo.
O Visual Studio Code é uma opção mais leve para programar, porém o Visual Studio 2019 é mais completo.


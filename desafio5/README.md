# Processe dados dos jogadores do FIFA© 2017

Utilizando C# e testes unitários, você deverá descobrir quais são os melhores jogadores, quais os mais valiosos e quais são suas nacionalidades.
Para isso deve implementar os métodos da classe `FIFACupStats` e os dados devem ser lidos do arquivo `data.csv` fornecido junto com o desafio.

O arquivo está no formato CSV (Comma Separated Values) que é o formato em que os valores de cada coluna são separados por um caractere `,`.
Nesse arquivo, a primeira linha contém os nomes das colunas referenciadas nas regras abaixo e deve ser desconsiderada para os cálculos.

Na classe `FIFICupStats` já existe uma propriedade ajustada para o caminho do arquivo e outra para o encoding dos dados do arquivo. Utilize essas propriedades quando construir o método que vai abrir o arquivo. Embora o arquivo `data.csv` esteja na pasta raiz do projeto, ele será copiado para a pasta de build quando o teste for executado.

## Regras para os métodos 

### NationalityDistinctCount

Deve retornar quantas nacionalidades diferentes existem no arquivo. Deve se basear nos dados da coluna `nationality` do arquivo. Não considerar os registros sem a nacionalidade.

### ClubDistinctCount

Deve retornar quantos clubes diferentes existem no arquivo. Deve se basear nos dados da coluna `club` do arquivo. Não considerar os registros sem o nome do clube.

### First20Players

Deve retornar uma lista com o nome completo dos 20 primeiros jogadores. Deve se basear nos dados da coluna `full_name` do arquivo.

### Top10PlayersByReleaseClause

Deve retornar quem são os 10 jogadores que possuem as maiores cláusulas de rescisão. Deve se basear nas colunas colunas `full_name` e `eur_release_clause` do arquivo.

### Top10PlayersByAge

Deve retornar quem são os 10 jogadores mais velhos. Deve se basear nos dados das colunas `full_name` e `birth_date` do arquivo. Utilize a coluna `eur_wage`, que representa o salário, como critério de desempate. Jogadores mais velhos que ganham mais têm a preferência.

### AgeCountMap

Deve retornar um dicionário com a quantidade de jogadores por idade. Deve se basear nos dados da coluna `age`. Para isso, construa um dicionário em que as chaves são as diferentes idades e o valor a contagem de jogadores com aquela idade.
	
## Tópicos

Neste desafio você aprenderá:

* Classes e objetos
* Ler arquivo CSV
* Processar grandes quantidades de dados

## Requisitos
​
Para este desafio você precisará :

- .NET Core 2.0+
- Visual Studio ou Visual Studio Code

Para instalar o .NET Core e o Visual Studio, confira os links na seção de conteúdo.
O Visual Studio Code é uma opção mais leve para programar, porém o Visual Studio 2019 é mais completo.

# Calculadora de Campos de Classe

O C# permite que um programa possa ter acesso os metadados de um `Assembly` qualquer através de um método chamado **Reflection**. Nesse desafio você irá utilizar esse método para somar ou subtrair determinados campos do tipo `decimal` de uma classe. Pra saber se você deve somar ou subtrair o valor desse campo, você deverá criar um atributo chamado `Add` que irá indicar que o valor do campo será somado e outro atributo chamado `Subtract` para indicar que o valor do campo será subtraído.

No C# damos o nome de atributo para as anotações que são feitas sobre as classes, métodos, propriedades, campos e argumentos. Essas anotações são adicionadas através do uso de colchetes antes da definição da classe, método, propriedade, etc. As classes que definem um atributo seguem uma convenção de ter o nome terminado por **Attribute** e herdam da classe base `Attribute`. No desafio suas classes de atributo terão o nome `AddAttribute` e `SubtractAttribute`. Damos o nome de "Decorar" ao procedimento de colocar esses atributos ou anotações nas classes. 

No C# damos o nome de campo as variáveis privadas ou protegidas definidas no contexto da classe que servem de suporte aos métodos ou propriedades das classes, porém não precisam ser expostas diretamente. Por exemplo, na classe abaixo, `salary` é um campo e `Add` é o atributo. Note que o uso do `_` no início do nome de um campo é uma convenção adotada por um grande parte dos programadores C# para que um campo seja facilmente diferenciado de uma variável local e para que não seja necessário o uso do `this`. Uma convenção mais antiga do .NET Framework recomenda usar apenas os nomes no padrão `camelCase` sem o `_`.

```csharp
	public class Employee
	{
		[Add]
		private decimal salary;
		
		public decimal GetSalary()
		{
			return this.salary;
		}
	}	
```  

## Calculadora

Nesse desafio você irá criar uma interface chamada `ICalculateField`. Esta interface terá três métodos:

- `Addition`
- `Subtraction`
- `Total`

Cada método irá receber uma instância de uma classe (`object`) e retornar um `decimal`.

Você deverá também criar uma classe que implementa a interface `ICalculateField`. O nome dessa classe deve ser `FieldCalculator`. A implementação dos métodos da interface deve obedecer as seguintes regras:

### Método `Addition`

Deverá retornar a soma de todos os campos do tipo `decimal` que tenham o atributo `Add`. Caso não existam campos do tipo `decimal` com atributo `Add`, retornar 0 (zero). 

Por exemplo:

- se uma classe tem um campo de valor 10 e outro de valor 20 com o atributo `Add` o resultado deve ser 30. 
- se uma classe tem um campo de valor -10 e outro de valor 20 com o atributo `Add` o resultado deve ser 10. 

### Método `Subtraction`

Deverá retornar a subtração de todos os campos do tipo `decimal` que tenham o atributo `Subtract`. Caso não existam campos do tipo `decimal` com atributo `Subtract`, retornar 0 (zero). 

Por exemplo:

- se uma classe tem um campo de valor 10 e outro de valor 20 com o atributo `Subtract` o resultado deve ser `0` - `10` - `20` = `-30`. 
- se uma classe tem um campo de valor -10 e outro de valor 20 com o atributo `Subtract` o resultado deve ser `0` - `-10` - `20` = `-10`. 

### Método `Total`

Deverá retornar soma de todos os campos do tipo `decimal` que tenham o atributo `Add` subtraídos de todos os campos que tenham o atributo `Subtract`. 
Caso não existam campos do tipo `decimal` com atributo `Add` ou `Subtract`, retornar 0 (zero). 

Por exemplo:

- se uma classe tem um campo de valor -10 com `Add`, outro de valor 20 com `Add`, outro de valor -10 com `Subtract` e outro de valor 20 com `Subtract`, o resultado deve ser `0` + `-10` + `20` - `-10` - `20` = `0` (zero)

## Testes

Para criar os testes você também terá que usar os conhecimentos de **Reflection** para verificar a construção correta da interface `ICalculateField` e a implementação correta da classe `FieldCalculator` antes mesmo de construir o código.

Lembre que para testar os métodos de `FieldCalculator` você também precisará construir classes de testes decoradas com os atributos `Add` e `Subtract`.

## Tópicos

Neste desafio você aprenderá:

* Classes e objetos
* Intefaces
* Reflection

## Requisitos
​
Para este desafio você precisará :

- .NET Core 2.0+
- Visual Studio ou Visual Studio Code

Para instalar o .NET Core e o Visual Studio, confira os links na seção de conteúdo.
O Visual Studio Code é uma opção mais leve para programar, porém o Visual Studio 2019 é mais completo.

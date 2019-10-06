# Criptografia de Júlio César

Segundo o Wikipedia, criptografia ou criptologia (em grego: kryptós, “escondido”, e gráphein, “escrita”) é o estudo e prática de princípios e técnicas para comunicação segura na presença de terceiros, chamados “adversários”. Mais geralmente, a criptografia refere-se à construção e análise de protocolos que impedem terceiros, ou o público, de lerem mensagens privadas. Muitos aspectos em segurança da informação, como confidencialidade, integridade de dados, autenticação e não-repúdio são centrais à criptografia moderna. Aplicações de criptografia incluem comércio eletrônico, cartões de pagamento baseados em chip, moedas digitais, senhas de computadores e comunicações militares. 
Das criptografias mais curiosas na história da humanidade podemos citar a criptografia utilizada pelo grande líder militar romano Júlio César para comunicar-se com os seus generais. Essa criptografia se baseava na substituição das letra do alfabeto avançando três casas. 

Para exemplificar essa técnica, vamos usar um pangrama, que é uma frase que utiliza todas as letras de um certo alfabeto. 

```
Normal:  the quick brown fox jumps over the lazy dog
Cifrado: wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj
```

O objetivo desse desafio é implementar os métodos da classe `CesarCypher` para a criptografar e descriptografar mensagens usando a Cifra de César:

Regras:

* As mensagens serão convertidas para minúsculas antes da criptografia e a descriptografia irá resultar em uma mensagem apenas com letras minúsculas.
* Os números e espaços não serão cifrados.
* Caso seja fornecido uma mensagem vazia para cifrar deve retornar um valor vazio
* Caso seja fornecida um valor para cifrar ou decifrar que contenha caracteres especiais ou letras acentuadas como ç, á, é, etc. devem disparar uma exceção do tipo `ArgumentOutOfRangeException`
* Caso seja fornecido um valor nulo para cifrar ou decifrar deve disparar uma exceção do tipo `ArgumentNullException`

A classe deve implementar as interfaces `ICrypt` e `IDecrypt` da seguinte forma:

- O método `Crypt` da interface `ICrypt` recebe uma `string` e retorna outra `string` com a mensagem cifrada.
- O método `Decrypt` da interface `IDecrypt` recebe uma `string` com a mensagem cifrada e retorna outra `string` com a mensagem decifrada.


## Tópicos

Neste desafio você aprenderá:

* Variáveis e métodos
* Manipular cadeias de caracteres
* Controle de fluxo

## Requisitos
​
Para este desafio você precisará :

- .NET Core 2.0+
- Visual Studio ou Visual Studio Code

Para instalar o .NET Core e o Visual Studio, confira os links na seção de conteúdo.
O Visual Studio Code é uma opção mais leve para programar, porém o Visual Studio 2019 é mais completo.


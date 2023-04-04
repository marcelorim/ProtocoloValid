<h1>Api para controle de processamento em fila</h1> 

> Status do Projeto: :warning: (em desenvolvimento)

### Tópicos 

:small_blue_diamond: [Descrição do projeto](#descrição-do-projeto)

:small_blue_diamond: [Funcionalidades](#funcionalidades)

:small_blue_diamond: [Deploy da Aplicação](#deploy-da-aplicação-dash)

:small_blue_diamond: [Pré-requisitos](#pré-requisitos)

:small_blue_diamond: [Como rodar a aplicação](#como-rodar-a-aplicação-arrow_forward)

## Descrição do projeto 

<p align="justify">
  Serviço para envio de protocolos para processamento em fila e consumo de forma assíncrona e persistencia no banco. 
</p>

## Funcionalidades

:heavy_check_mark: Incluir dados na fila  

:heavy_check_mark: Obter protocolo por número  

:heavy_check_mark: Obter protocolo por CPF  

:heavy_check_mark: Obter protocolo por RG  

## Layout ou Deploy da Aplicação :dash:

> Projeto para ser executado no modo start multiplo no visual studio 2022, setando como inicialização od projetos: Protocolo.Consumer.App e Protocolo.Publisher.App

## Pré-requisitos

:warning: [.NET6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
:warning: [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/community/)
:warning: [Doker Desktop](https://www.docker.com/products/docker-desktop/)
:warning: [Ubuntu](https://ubuntu.com/download/desktop)
:warning: [Sql Server Express 2019](https://www.microsoft.com/pt-br/download/details.aspx?id=101064)
:warning: [Sql Management Studio](https://learn.microsoft.com/pt-BR/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
:warning: [Github](https://github.com/)
:warning: [Bogus](https://github.com/bchavez/Bogus)

## Como rodar a aplicação :arrow_forward:

Rodar no visual studio 2022: 

```
git clone https://github.com/marcelorim/ProtocoloValid
```
 
## JSON :floppy_disk:

### Usuários: 

Para realizar a autenticação na api é necessário enviar o usuário e senha para obter o token de acesso aos endpoints.
|login|senha|token|
| -------- |-------- |-------- |
|valid|valid@1234|true|

## Desenvolvedores/Contribuintes :octocat:

| [<img src="https://avatars.githubusercontent.com/u/1753492?s=400&v=4" width=115><br><sub>Marcelo Ferreira</sub>](https://github.com/marcelorim) | 
| :---: |

## Licença 

Copyright :copyright: 2023 - Protocolo Valid

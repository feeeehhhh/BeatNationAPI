# MarketPlace (BeatNation) - API

## Descrição
O BeatNation é uma API em desenvolvimento criada com o objetivo de praticar e aplicar conceitos mais avançados de desenvolvimento backend.

A proposta do projeto é simular um marketplace de beats (instrumentais musicais), onde produtores podem publicar seus beats, definir tipos de licença de uso e disponibilizar seus trabalhos para venda.

Este projeto não tem como foco principal ser um sistema pronto para produção neste momento, mas sim servir como ambiente de aprendizado para estudar arquitetura de software e boas práticas utilizadas em aplicações reais.

Durante o desenvolvimento estão sendo explorados conceitos como:

- ASP.NET Core
- Arquitetura CQRS (Command Query Responsibility Segregation)
- MediatR para desacoplamento entre camadas
- FluentValidation para validação de dados
- Entity Framework Core para acesso ao banco
- Separação de responsabilidades
- Organização de um backend escalável

O objetivo é evoluir o projeto gradualmente, aplicando melhorias conforme novos conhecimentos forem sendo adquiridos.

---

## Status

🚧 Em desenvolvimento

Projeto criado para fins de estudo e prática de arquitetura backend.  
A estrutura pode sofrer alterações conforme o projeto evolui.

---

## Funcionalidades

- Upload de Beats 🚧 (Em desenvolvimento)
- Listagem de Beats 🚧 (Em desenvolvimento)
- Criação de Licenças ✅ (Implementado)
- Listagem de Licenças ✅ (Implementado)
- Carrinho de Compras ❌ (Não implementado)
- Curtidas nos Beats ❌ (Não implementado)
- Sistema de reputação de produtores ❌ (Não implementado)

---

## Tecnologias

- ASP.NET Core
- MediatR
- FluentValidation
- Entity Framework Core
- SQL Server
- DotEnv

---

## Estrutura

Application/  
Responsável pelas regras da aplicação, utilizando o padrão CQRS.

Controllers/  
Responsável por receber as requisições HTTP.

Data/  
Responsável pela configuração das entidades e contexto do banco de dados.

Infra/  
Responsável por configurações externas, como variáveis de ambiente (.env).

Migrations/  
Armazena o histórico de alterações no banco de dados.

Models/  
Define a estrutura dos dados da aplicação.

---

## Como executar

### Pré-requisitos

- Ter um banco de dados SQL Server rodando
- Possuir uma string de conexão válida

---

### Passo a passo

1. Clonar o repositório

    git clone https://github.com/feeeehhhh/BeatNationAPI.git

2. Entrar na pasta do projeto

    cd BeatNationAPI

3. Configurar a conexão com o banco de dados

    No arquivo:

    "appsettings.json"  

    adicione sua string de conexão:

    ![alt text](<string conection-2.png>)

4. Rodar o projeto

    dotnet run


## Documentação da API (Swagger)

A documentação completa dos endpoints está disponível via Swagger após iniciar a aplicação.

Após rodar o projeto, acesse:

https://localhost:5001/swagger

ou

http://localhost:5000/swagger

O Swagger permite:

- visualizar todos os endpoints disponíveis
- testar requisições diretamente no navegador
- ver parâmetros obrigatórios
- ver exemplos de respostas

## Objetivo do projeto

Este projeto foi criado com foco em aprendizado e prática de arquitetura backend.

A ideia é evoluir a aplicação gradualmente, aplicando conceitos mais avançados conforme o conhecimento for evoluindo.
# 💲 Microsserviço de Gerenciamento de Transações Financeiras

Este projeto é uma aplicação de exemplo para gerenciamento de transações financeiras, desenvolvida com ASP.NET Core e seguindo os princípios da **Arquitetura Limpa (Clean Architecture)**. 
Ele demonstra uma API simples, desacoplada e testável, utilizando MongoDB para persistência e Azure Service Bus para comunicação assíncrona.

## 🚀 Tecnologias Utilizadas

* **Framework:** .NET 8.0
* **Web Framework:** ASP.NET Core Web API
* **Banco de Dados:** MongoDB Atlas (via MongoDB.EntityFrameworkCore)
* **Mensageria:** Azure Service Bus
* **Mediator Pattern:** MediatR
* **Mapeamento de Objetos:** AutoMapper
* **Testes Unitários:** xUnit.net
* **Mocking Framework:** Moq

## Estrutura do Projeto

O projeto é estruturado com base nos princípios da Clean Architecture (também conhecida como Onion Architecture ou Hexagonal Architecture). 
Cada camada tem uma responsabilidade específica e as dependências fluem de fora para dentro, garantindo que o núcleo da aplicação (Domínio e Aplicação) seja independente de tecnologias e frameworks externos.

### Estrutura de Pastas e Projetos:

```
gerenciamento_transacoes.sln
├── Core
│   ├── gerenciamento_transacoes.Application  (Camada de Aplicação)
│   └── gerenciamento_transacoes.Domain       (Camada de Domínio)
├── Infrastructure
│   ├── gerenciamento_transacoes.Persistence  (Camada de Infraestrutura/Persistência)│   
└── Presentation
|   ├── gerenciamento_transacoes.API          (Camada de Apresentação/API)
└── Test
    └── gerenciamento_transacoes.Test
```

## 🛠️ Como Iniciar o Projeto

Siga estas instruções para configurar e rodar o projeto em sua máquina local:

### Pré-requisitos

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (recomendado) ou um editor de código de sua preferência (VS Code, Rider).
* Conta no [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) (ou uma instância local do MongoDB).
* Conta no [Azure Service Bus](https://azure.microsoft.com/services/service-bus/) (Namespace e fila criados).

### Configuração

1.  **Clone o Repositório:**
    ```
    git clone git@github.com:JoaoCarlos22/microsservico-transacoes.git
    cd gerenciamento_transacoes
    ```

2.  **Configurações de Conexão e Segredos:**
    * No Visual Studio, clique com o botão direito nos projetos `gerenciamento_transacoes.API` e `gerenciamento.transacoes.Persistence` e selecione **"Manage User Secrets"**.
    * Configure seu `secrets.json` com as seguintes informações:
        ```json
        {
          "ConnectionStrings": {
            "DatabaseUrl": "mongodb+srv://<seu_usuario>:<sua_senha>@<seu_cluster_url>/<seu_database_name>?retryWrites=true&w=majority&appName=<seu_app_name>",
            "DatabaseName": "seu_database_name"
          },
          "AzureServiceBus": {
            "Namespace": "seu-namespace.servicebus.windows.net",
            "QueueName": "nome-da-sua-fila"
          }
        }
        ```
        * **ATENÇÃO:** Substitua os placeholders `<...>` com seus próprios valores do MongoDB Atlas e Azure Service Bus.

3.  **Autenticação no Azure:**
    Para que `DefaultAzureCredential()` funcione em desenvolvimento, você precisa autenticar sua conta Azure:
    * **Via Visual Studio:** Vá em `Tools > Options > Azure Service Authentication` e faça login na sua conta Azure.
    * **Via Azure CLI:** Abra um terminal e execute `az login`.

### Rodando a Aplicação API

1.  **Pelo Visual Studio:**
    * Clique com o botão direito no projeto `gerenciamento_transacoes.API` e selecione **"Set as Startup Project"**.
    * Pressione **F5** ou clique no botão `Start` na barra de ferramentas.
    * O navegador será aberto no Swagger UI (`https://localhost:5244/swagger/index.html`).

2.  **Pelo Terminal:**
    * Navegue até a pasta do projeto `gerenciamento_transacoes.API` no terminal.
    * Execute: `dotnet run`
  
### Endpoints disponíveis

- **GET/api/Transaction:** recuperar todaas as transações exsitentes no banco de dados;
- **POST/api/Transaction:** cria uma nova instância de uma transação, salva no banco de dados e envia a mensagem para a fila no Azure Service Bus.

### Rodando os Testes Unitários

-  **Pelo Terminal:**
    * Navegue até a pasta raiz da sua solução (`gerenciamento_transacoes`).
    * Execute: `dotnet test`
    * Para testar um projeto específico: `dotnet test gerenciamento_transacoes.Test`

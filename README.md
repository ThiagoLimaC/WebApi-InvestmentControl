# WebApi-InvestmentControl

<img src="wwwroot/videoApiInvestimentControl.gif" width="700">

## Visão Geral

O **WebApi-InvestmentControl** é uma API RESTful desenvolvida em .NET 9 para gerenciar investimentos. Ela permite cadastrar, consultar, atualizar e remover investimentos, fornecendo respostas padronizadas para facilitar a integração com frontends ou outros sistemas.

---

## Arquitetura Utilizada

O sistema adota uma arquitetura baseada em camadas, utilizando os padrões **Repository** e **Service**, além de aplicar o conceito de **injeção de dependência**. Essa abordagem promove organização, testabilidade e manutenção facilitada do código.

### Camadas e Padrões

- **Controller:** Responsável por receber as requisições HTTP e encaminhá-las para a camada de serviço, retornando as respostas apropriadas.
- **Service:** Contém as regras de negócio e orquestra as operações, utilizando os repositórios para acessar os dados. Também é responsável por retornar modelos de resposta (DTOs ou Response Models) para os controllers.
- **Repository:** Realiza o acesso direto ao banco de dados, encapsulando a lógica de persistência e consulta de dados. Expõe interfaces para facilitar a troca de implementações e testes.

### Injeção de Dependência

A aplicação utiliza o mecanismo de injeção de dependência do .NET para gerenciar as instâncias das classes. Isso significa que as dependências (por exemplo, repositórios e serviços) são fornecidas automaticamente pelo framework, sem a necessidade de instanciá-las manualmente.

**Exemplo de registro no `Program.cs`:**

`builder.Services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();` <br>
` builder.Services.AddScoped();`

### Vantagens Dessa Arquitetura

- **Separação de responsabilidades:** Cada camada tem uma função bem definida, facilitando a manutenção e evolução do sistema.
- **Testabilidade:** Com a injeção de dependência e o uso de interfaces, é fácil criar testes unitários utilizando mocks para isolar o comportamento de cada camada.
- **Reutilização de código:** A lógica de acesso a dados e as regras de negócio ficam centralizadas, evitando duplicidade.
- **Facilidade de manutenção:** Mudanças em uma camada (por exemplo, trocar o banco de dados) não afetam diretamente as outras, desde que as interfaces sejam mantidas.
- **Escalabilidade:** A arquitetura modular permite adicionar novas funcionalidades ou camadas (como cache, validação, etc.) de forma simples.

#### Diagrama Simplificado

```
Controller
    |
    v
 Service
    |
    v
 Repository
    |
    v
  Database
```
---

## Tecnologias Utilizadas

- .NET 9
- C# 13
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI

---

## Requisitos

- .NET 9 SDK
- SQL Server (ou outro banco de dados compatível)
- Visual Studio 2022 ou superior

---

## Configuração do Projeto

1. **Clone o repositório:**

```
git clone https://github.com/seu-usuario/WebApi-InvestmentControl.git 
cd WebApi-InvestmentControl
```


2. **Configure a string de conexão:**
   - No arquivo `appsettings.json`, ajuste a chave `DefaultConnection` para apontar para seu banco de dados SQL Server.

3. **Restaure os pacotes e execute as migrações:** <br>
`dotnet restore` <br>
`dotnet ef database update`

4. **Execute a aplicação:** <br>
`dotnet run`

5. **Acesse a documentação Swagger:**
   - Navegue até `https://localhost:5001/swagger` ou conforme a porta configurada.

---

## Estrutura do Projeto

```
WebApi-InvestmentControl/          

├── Controllers/                  
    └── InvestimentoController.cs  
├── Models/                          
|    ├── InvestimentoModel.cs        
|    └── ResponseModel.cs 
├── Repositories/    
|    ├── InvestimentoRepository.cs 
|    └── Interfaces/        
|            └── IInvestimentoRepository.cs 
├── Services/    
|    └── InvestimentoService.cs 
├── Data/    
|      └── AppDbContext.cs 
├── Program.cs 
└── README.md
```
   
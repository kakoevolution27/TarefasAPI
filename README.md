# TarefasAPI

Uma API RESTful em .NET para gerenciamento de tarefas e categorias, construída com Entity Framework Core e PostgreSQL.

## Tecnologias

- **.NET 10** - Framework principal para a API
- **Entity Framework Core** - ORM para mapeamento objeto-relacional
- **PostgreSQL** - Banco de dados relacional
- **Docker & Docker Compose** - Containerização e orquestração
- **ASP.NET Core WebAPI** - Framework para construção da API RESTful

## Como rodar

### Opção 1: Usando Docker Compose (Recomendado)

1. Navegue até o diretório do projeto:
```bash
cd /root/workspace/TarefasAPI
```

2. Suba os containers:
```bash
docker-compose up --build
```

3. A API estará disponível em: `http://localhost:8080`

### Opção 2: Rodando localmente

1. Certifique-se de ter PostgreSQL configurado e crie o banco `TarefasDb`

2. Atualize a string de conexão no `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "StringConexaoPostgres": "Host=localhost;Port=5432;Database=TarefasDb;Username=postgres;Password=sua_senha"
  }
}
```

3. Instale as dependências:
```bash
dotnet restore
```

4. Execute as migrações para criar as tabelas:
```bash
dotnet ef database update
```

5. Rode a API:
```bash
dotnet run
```

6. Acesse em: `http://localhost:5222`

## Endpoints

### Categorias

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/categoria` | Listar todas as categorias |
| POST | `/api/categoria` | Criar uma nova categoria |
| PUT | `/api/categoria/{id}` | Atualizar uma categoria existente |
| DELETE | `/api/categoria/{id}` | Excluir uma categoria |

### Exemplo de requisição para criar categoria:

```json
{
  "nome": "Trabalho"
}
```

## O que aprendi

Neste projeto, implementei:

- **Arquitetura em camadas (3-layers)**: Separei a aplicação em Controllers, Services e Repositories para seguir o princípio de Single Responsibility e tornar o código mais organizado e manutenível.

- **Injeção de Dependência**: Configurei o DI nativo do .NET para injetar os serviços e repositórios, promovendo acoplamento fraco e facilitando os testes unitários.

- **Entity Framework Core com Code First**: Utilizei EF Core para mapear meus modelos (Categoria e Tarefa) para tabelas no banco de dados, configurando relacionamentos e usando migrations para gerenciar o schema do banco.

- **Padrão Repository**: Criei uma camada de repositório abstraindo as operações de banco de dados, o que deixa meu código mais limpo e testável.

- **Service Layer**: Implementei uma camada de serviços para encapsular a lógica de negócios, separando-a completamente dos controllers.

- **CRUD completo com tratamento de exceções**: Para cada operação (criar, ler, atualizar, excluir), implementei try-catch para tratar erros e retornar os status HTTP adequados (200 OK, 201 Created, 404 NotFound, 204 No Content).

- **Configuração de PostgreSQL com Docker**: Configurei o banco PostgreSQL dentro do container, utilizando Docker Compose para orquestrar tanto a API quanto o banco de dados.

- **Program.cs e configuração de serviços**: Aprendi como configurar corretamente o pipeline da aplicação ASP.NET Core, incluindo DbContext, conexões com banco de dados e middlewares.

# clob

Estrutura básica de projeto **.NET** com **Clean Architecture** e **CQRS**.

## Estrutura

- `src/Clob.Domain`: regras e entidades de domínio.
- `src/Clob.Application`: casos de uso, abstrações e handlers de comando/query.
- `src/Clob.Infrastructure`: implementação de persistência em memória.
- `src/Clob.Api`: API minimal para expor comandos e queries.
- `tests/Clob.Application.Tests`: testes focados na camada de aplicação.

## Como executar

```bash
dotnet build Clob.slnx
dotnet test Clob.slnx
dotnet run --project /home/runner/work/legendary-broccoli/legendary-broccoli/src/LegendaryBroccoli.Api/LegendaryBroccoli.Api.csproj
```

## Endpoints

- `POST /todos` com body `{ "title": "Minha tarefa" }`
- `GET /todos`
- `GET /todos/{id}`

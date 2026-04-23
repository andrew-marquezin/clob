# legendary-broccoli

Estrutura básica de projeto **.NET** com **Clean Architecture** e **CQRS**.

## Estrutura

- `src/LegendaryBroccoli.Domain`: regras e entidades de domínio.
- `src/LegendaryBroccoli.Application`: casos de uso, abstrações e handlers de comando/query.
- `src/LegendaryBroccoli.Infrastructure`: implementação de persistência em memória.
- `src/LegendaryBroccoli.Api`: API minimal para expor comandos e queries.
- `tests/LegendaryBroccoli.Application.Tests`: testes focados na camada de aplicação.

## Como executar

```bash
dotnet build LegendaryBroccoli.slnx
dotnet test LegendaryBroccoli.slnx
dotnet run --project /home/runner/work/legendary-broccoli/legendary-broccoli/src/LegendaryBroccoli.Api/LegendaryBroccoli.Api.csproj
```

## Endpoints

- `POST /todos` com body `{ "title": "Minha tarefa" }`
- `GET /todos`
- `GET /todos/{id}`

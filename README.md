## Instruções

1. Instalar SDK .NET 5.0: <https://dotnet.microsoft.com/download/dotnet/5.0>
2. Instalar ferramentas CLI de migrations do EF Core
```bash
dotnet tool install --global dotnet-ef
```

3. Subir instância postgres para teste
```bash
docker run -d --name postgres -e POSTGRES_PASSWORD=123456 -p 5432:5432 postgres:12.2-alpine
```

4. Aplicar migrations
```bash
cd ConsoleApp
dotnet ef database update
```

5. Executar aplicação
```bash
dotnet run
```

## Migrations

Adicionar migrations

```bash
dotnet ef migrations add Inicio
```

Atualizar base de dados

```bash
dotnet ef database update
```

Remover migrations e resetar base de dados

```bash
dotnet ef database update 0
dotnet ef migrations remove
```

## Queries

LINQ Query

```csharp
var query = conn.Fretes
    .Where(x => x.Remetente.Cidade.UF == "SC")
    .Select(x => new
    {
        x.Id,
        x.Valor,
        NomeRemetente = x.Remetente.Nome,
        NomeDestinatario = x.Destinatario.Nome,
        CidadeRemente = x.Remetente.Cidade.Nome,
        CidadeDestinatario = x.Destinatario.Cidade.Nome
    });
var fretes = query.ToList();
```

Tradução SQL

```sql
SELECT f."Id", f."Valor", c."Nome" AS "NomeRemetente", c1."Nome" AS "NomeDestinatario", c0."Nome" AS "CidadeRemente", c2."Nome" AS "CidadeDestinatario"
FROM frete AS f
INNER JOIN cliente AS c ON f."RemetenteId" = c."Id"
INNER JOIN cidade AS c0 ON c."CidadeId" = c0."Id"
INNER JOIN cliente AS c1 ON f."DestinatarioId" = c1."Id"
INNER JOIN cidade AS c2 ON c1."CidadeId" = c2."Id"
WHERE c0."UF" = 'SC'
```

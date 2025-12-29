# Sistema de Vendas – Windows Forms

## Tecnologias
- .NET 7 (C#)
- Windows Forms
- PostgreSQL 17.7
- Npgsql
- FluentValidation

## Arquitetura
Aplicação organizada em camadas:
- Host (Windows Forms)
- Domain (Regras de negócio + Validators)
- Persistence (Repositories)

## Decisões Técnicas
- FluentValidation aplicado no Domain
- Repository responsável apenas por acesso a dados

## Como Executar 
(Já possui um banco publicado na https://aiven.io/. Neste caso execute a partir do passo 3.)
1. Executar `script_db.sql`
2. Ajustar connection string no arquivo appsettings.json
3. Restaurar pacotes NuGet
4. Executar o projeto PedroFarah.WFVendas.Host

```text
+----------------------+
|   Windows Forms      |
|        Host          |
+----------+-----------+
           |
           v
+----------------------+
|       Domain         |
|      Services        |
| + FluentValidation   |
+----------+-----------+
           |
           v
+----------------------+
|     Repositories     |
|  (Npgsql / Async)    |
+----------+-----------+
           |
           v
+----------------------+
|   PostgreSQL 17.7    |
|  Constraints / FK    |
+----------------------+
```
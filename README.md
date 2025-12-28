# Sistema de Vendas – Windows Forms

## Tecnologias
- .NET 9 (C#)
- Windows Forms
- PostgreSQL 17.7
- Npgsql
- FluentValidation
- ReportViewer

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

┌────────────────────┐
│   Windows Forms    │
│        Host        │
└─────────┬──────────┘
          ↓
┌────────────────────┐
│       Domain       │
│      Services      │ 
│ + FluentValidation │
└─────────┬──────────┘
          ↓
┌────────────────────┐
│    Repositories    │
│  (Npgsql / Async)  │
└─────────┬──────────┘
          ↓
┌────────────────────┐
│    PostgreSQL 17.7 │
│ Constraints / FK   │
└────────────────────┘

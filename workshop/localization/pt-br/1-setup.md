# Pré-requisitos

Este workshop utilizará as seguintes ferramentas:

- [SDK do .NET 8](https://dot.net/download)
- [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)
- [Docker Desktop](https://docs.docker.com/engine/install/) ou [Podman](https://podman.io/getting-started/installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) ou [Visual Studio Code](https://code.visualstudio.com/) com [C# DevKit](https://code.visualstudio.com/docs/csharp/get-started)

Para uma experiência melhor, recomendamos usar o Visual Studio 2022 com .NET Aspire. No entanto, você pode usar o Visual Studio Code com o C# Dev Kit e o .NET Aspire. A seguir estão os passos para configuração de cada plataforma.

## Windows com Visual Studio

- Instale o [Visual Studio 2022 versão 17.10 ou mais recente](https://visualstudio.microsoft.com/vs/).
  - Selecione os componentes:
    - `ASP.NET and web development`.
    - `.NET Aspire SDK` em `Componentes individuais`.

## Mac, Linux e Windows sem Visual Studio
- Instale o último [SDK do .NET 8](https://dotnet.microsoft.com/download)
- Instale o [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire) com os seguintes comandos:

```powershell
dotnet workload update
dotnet workload install aspire
```

> Nota: Estes comandos podem requerer `sudo`

- Instale o [Visual Studio Code com C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

> Nota: Ao executar no Mac com processador Apple Silicon (série M), Rosetta 2 para grpc-tools.

## Teste de Instalação

Para testar sua instalação, consulte [Construa seu primeiro projeto .NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app) para mais informações.

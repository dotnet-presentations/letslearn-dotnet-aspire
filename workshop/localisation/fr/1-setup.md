# Configuration de la machine

Cet atelier utilisera les outils suivants:

- [.NET 8 SDK](https://dot.net/download)
- [.NET Aspire Workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)
- [Docker Desktop](https://docs.docker.com/engine/install/) or [Podman](https://podman.io/getting-started/installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/) with [C# DevKit](https://code.visualstudio.com/docs/csharp/get-started)

Pour une expérience optimale, nous vous recommandons d'utiliser Visual Studio 2022 avec le "workload" .NET Aspire. Toutefois, vous pouvez utiliser Visual Studio Code avec le kit de développement C# et le "workload" .NET Aspire. Vous trouverez ci-dessous des guides de configuration pour chaque plate-forme.


## Windows avec Visual Studio
- Installer [Visual Studio 2022 version 17.10 ou plus récent](https://visualstudio.microsoft.com/vs/).
  - Sélectionnez les charges de travail (workloads) suivantes:
    - `ASP.NET and web development` workload.
    - `.NET Aspire SDK` component in `Individual components`.

## Mac, Linux, & Windows sans Visual Studio
- Installer le dernier [.NET 8 SDK](https://dot.net/download?cid=eshop)
- Installer [.NET Aspire workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire) avec les commandes suivantes:

```powershell
dotnet workload update
dotnet workload install aspire
```

> Remarque : Ces commandes peuvent nécessiter `sudo`

- Installer [Visual Studio Code avec C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

> Remarque: Lors de l'exécution sur Mac avec Apple Silicon (processeur série M), Rosetta 2 pour les outils grpc.


## Tester l’installation
Pour tester votre installation, consultez [Build your first .NET Aspire project](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app) pour plus d'informations.

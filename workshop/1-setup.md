# Machine Setup 

This workshop will be using the following tools:

- [.NET 8 SDK](https://dot.net/download)
- [.NET Aspire Workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)
- [Docker Desktop](https://docs.docker.com/engine/install/) or [Podman](https://podman.io/getting-started/installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/) with [C# DevKit](https://code.visualstudio.com/docs/csharp/get-started)

For the best experience, we recommend using Visual Studio 2022 with the .NET Aspire workload. However, you can use Visual Studio Code with the C# Dev Kit and .NET Aspire workload. Below are setup guides for each platform.

## Windows with Visual Studio
- Install [Visual Studio 2022 version 17.10 or newer](https://visualstudio.microsoft.com/vs/).
  - Select the following workloads:
    - `ASP.NET and web development` workload.
    - `.NET Aspire SDK` component in `Individual components`.

## Mac, Linux, & Windows without Visual Studio
- Install the latest [.NET 8 SDK](https://dot.net/download?cid=eshop)
- Install the [.NET Aspire workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire) with the following commands:

```powershell
dotnet workload update
dotnet workload install aspire
```

> Note: These commands may require `sudo`

- Install [Visual Studio Code with C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

> Note: When running on Mac with Apple Silicon (M series processor), Rosetta 2 for grpc-tools. 


## Test Installation
To test your installation, see the [Build your first .NET Aspire project](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app) for more information.

## Open Workshop Start Solution

To start the workshop open `start-with-api/MyWeatherHub.sln` in Visual Studio 2022. If you are using Visual Studio code open the `start-with-api` folder and when prompted by the C# Dev Kit which solution to open, select **MyWeatherHub.snl**.

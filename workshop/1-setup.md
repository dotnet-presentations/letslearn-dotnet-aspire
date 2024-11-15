# Machine Setup

This workshop will be using the following tools:

- [.NET 8 SDK](https://dot.net/download)
- [.NET Aspire Workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)
- [Docker Desktop](https://docs.docker.com/engine/install/) or [Podman](https://podman.io/getting-started/installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

For the best experience, we recommend using Visual Studio 2022 with the .NET Aspire workload. However, you can use Visual Studio Code with the C# Dev Kit and .NET Aspire workload. Below are setup guides for each platform.

## Windows with Visual Studio

- Install [Visual Studio 2022 version 17.12 or newer](https://visualstudio.microsoft.com/vs/).
  - Any edition will work including the [free to use Visual Studio Community](https://visualstudio.microsoft.com/free-developer-offers/)
  - Select the following `ASP.NET and web development` workload.

> Note: .NET Aspire 8.0 required installing a separate .NET Aspire workload. [In .NET 9, this workload is no longer required](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/upgrade-to-aspire-9?pivots=visual-studio) and can be uninstalled.

## Mac, Linux, & Windows without Visual Studio

- Install the latest [.NET 9 SDK](https://get.dot.net/9?cid=eshop)

- Install [Visual Studio Code with C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

> Note: When running on Mac with Apple Silicon (M series processor), Rosetta 2 for grpc-tools.

## Test Installation

To test your installation, see the [Build your first .NET Aspire project](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app) for more information.

## Open Workshop Start Solution

To start the workshop open `start-with-api/MyWeatherHub.sln` in Visual Studio 2022. If you are using Visual Studio code open the `start-with-api` folder and when prompted by the C# Dev Kit which solution to open, select **MyWeatherHub.sln**.

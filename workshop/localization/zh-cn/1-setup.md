# 环境设置

本研讨会需要使用如下开发工具:

- [.NET 9 SDK](https://get.dot.net/9)
- 或者 [.NET 8 SDK](https://get.dot.net/8) 与 [.NET Aspire Workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)
- [Docker Desktop](https://docs.docker.com/engine/install/) 或者 [Podman](https://podman.io/getting-started/installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) 或者 [Visual Studio Code](https://code.visualstudio.com/) 和 [C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

为了获得最佳体验，我们推荐使用将 Visual Studio 2022 与 .NET Aspire 工作负载一起使用。但是，您也可以将 Visual Studio Code 与 C# Dev Kit 和 .NET Aspire 工作负载一起使用。以下是每个平台的设置指南。

## Windows 平台上使用 Visual Studio

- 安装 [Visual Studio 2022 version 17.12 或更新的版本](https://visualstudio.microsoft.com/vs/).
  - 所有此版本的发行版都可以，包括 [免费 Visual Studio 社区版](https://visualstudio.microsoft.com/free-developer-offers/)
  - 选择 `ASP.NET and web development` 工作负载.

> 注意: .NET Aspire 8.0 要求额外安装 .NET Aspire 工作负载. [对于 .NET 9, 该工作负载不再需要](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/upgrade-to-aspire-9?pivots=visual-studio) ，它可以被卸载掉。

## Mac, Linux, & Windows 平台下不使用 Visual Studio

- 安装最新版 [.NET 9 SDK](https://get.dot.net/9?cid=eshop)

- 安装 [Visual Studio Code with C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

> 注意: 在装有 Apple Silicon（M 系列处理器）的 Mac 上运行时，还需要 Rosetta 2 for grpc-tools。

## 测试安装

为了测试安装, 请查阅 [构建您的第一个 .NET Aspire 项目](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app) 以获得更详尽信息.

## 打开研讨会的起始解决方案

在 Visual Studio 2022 中打开 `start-with-api/MyWeatherHub.sln` 解决方案，开始研讨会。如果您在使用 Visual Studio code，打开 `start-with-api` 文件夹，当 C# Dev Kit 提示打开哪个解决方案时，选择 **MyWeatherHub.sln**。

**下一节**: [模块 #2 - Service Defaults](2-servicedefaults.md)
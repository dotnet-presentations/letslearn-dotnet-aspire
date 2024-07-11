# マシンのセットアップ

このワークショップでは、以下のツールを使用します:

- [.NET 8 SDK](https://dot.net/download)
- [.NET Aspire Workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)
- [Docker Desktop](https://docs.docker.com/engine/install/) or [Podman](https://podman.io/getting-started/installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/) with [C# DevKit](https://code.visualstudio.com/docs/csharp/get-started)


最良の体験を得るためには、.NET Aspire workload が用意された Visual Studio 2022 を使用することをお勧めします。ただし、C# Dev Kit と .NET Aspire workload が用意された Visual Studio Code を使用することもできます。以下に各プラットフォームのセットアップガイドを示します。

## Windows with Visual Studio
- [Visual Studio 2022 version 17.10 以降](https://visualstudio.microsoft.com/vs/) をインストールします。
  - 以下のワークロードを選択します:
    - `ASP.NET と Web 開発` ワークロード。
    - `個別のコンポーネント` で `.NET Aspire SDK` コンポーネントを選択します。

## Mac, Linux, & Windows without Visual Studio
- 最新の [.NET 8 SDK](https://dot.net/download?cid=eshop) をインストールします
- 以下のコマンドを使用して、[.NET Aspire workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)  をインストールします:

```powershell
dotnet workload update
dotnet workload install aspire
```

> Note: これらのコマンドは `sudo` が必要な場合があります

- [Visual Studio Code with C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started) をインストールします

> Note: When running on Mac with Apple Silicon (M series processor), Rosetta 2 for grpc-tools. 

```bash

## Test Installation
インストールをテストするには、[Quickstart: Build your first .NET Aspire project](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app) を参照してください。
```
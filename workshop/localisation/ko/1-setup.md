> 이 문서는 [Azure OpenAI](https://learn.microsoft.com/azure/ai-services/openai/overview)를 이용해 초벌 번역 후 검수를 진행했습니다. 따라서 번역 품질이 기대와 다를 수 있습니다. 문서 번역에 대해 제안할 내용이 있을 경우, [이슈](./issue)에 남겨주시면 확인후 반영하겠습니다.

# 머신 설정

이 워크숍에서는 다음 도구들을 사용합니다:

- [.NET 8 SDK](https://dot.net/download)
- [.NET Aspire Workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)
- [Docker Desktop](https://docs.docker.com/engine/install/) 또는 [Podman](https://podman.io/getting-started/installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) 또는 [Visual Studio Code](https://code.visualstudio.com/)와 [C# DevKit](https://code.visualstudio.com/docs/csharp/get-started)

최고의 경험을 위해서는 .NET Aspire 워크로드가 포함된 Visual Studio 2022를 사용하는 것을 권장합니다. 하지만, C# Dev Kit과 .NET Aspire 워크로드가 포함된 Visual Studio Code를 사용할 수도 있습니다. 각 플랫폼에 대한 설정 가이드는 아래에 있습니다.

## Windows 환경에서 Visual Studio 사용하기

- [Visual Studio 2022 버전 17.10 이상](https://visualstudio.microsoft.com/vs/)을 설치합니다.
  - 다음 워크로드를 선택합니다:
    - `ASP.NET 및 웹 개발` 워크로드.
    - `개별 구성 요소`의 `.NET Aspire SDK` 구성 요소.

## Mac, Linux, Windows 환경에서 Visual Studio 없이 사용하기

- 최신 [.NET 8 SDK](https://dot.net/download?cid=eshop)를 설치합니다.
- 다음 명령어를 사용하여 [.NET Aspire 워크로드](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)를 설치합니다:

```powershell
dotnet workload update
dotnet workload install aspire
```

> 참고: 이 때 `sudo` 명령어를 사용해야 할 수도 있습니다.

- [C# Dev Kit을 포함한 Visual Studio Code](https://code.visualstudio.com/docs/csharp/get-started)를 설치합니다.

> 참고: Apple Silicon (M 시리즈 프로세서)을 사용하는 Mac에서 실행할 때는 grpc-tools를 위해 Rosetta 2가 필요합니다.

## 설치 테스트

설치를 테스트해 보려면, [첫 .NET Aspire 프로젝트 빌드하기](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app)에서 자세한 정보를 참조하세요.

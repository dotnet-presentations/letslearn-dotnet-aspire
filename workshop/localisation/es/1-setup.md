# Configuración del sistema

Este taller utilizará las siguientes herramientas:

- [.NET 8 SDK](https://dot.net/download)
- [Carga de trabajo de .NET Aspire](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire)
- [Docker Desktop](https://docs.docker.com/engine/install/) o [Podman](https://podman.io/getting-started/installation)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) o [Visual Studio Code](https://code.visualstudio.com/) con [C# DevKit](https://code.visualstudio.com/docs/csharp/get-started)

Para obtener la mejor experiencia, recomendamos utilizar Visual Studio 2022 con la carga de trabajo de .NET Aspire. Sin embargo, también puedes utilizar Visual Studio Code con el C# Dev Kit y la carga de trabajo de .NET Aspire. A continuación, se muestran las guías de configuración para cada plataforma.

## Windows con Visual Studio

- Instala [Visual Studio 2022 versión 17.10 o posterior](https://visualstudio.microsoft.com/vs/).
  - Selecciona las siguientes cargas de trabajo:
    - Carga de trabajo de `ASP.NET y desarrollo web`.
    - Componente `.NET Aspire SDK` en `Componentes individuales`.

## Mac, Linux y Windows sin Visual Studio

- Instala la última versión del [.NET 8 SDK](https://dot.net/download?cid=eshop)
- Instala la carga de trabajo de [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire) con los siguientes comandos:

```powershell
dotnet workload update
dotnet workload install aspire
```

> Nota: Es posible que estos comandos requieran `sudo`.

- Instala [Visual Studio Code con C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

> Nota: Cuando se ejecuta en Mac con Apple Silicon (procesador de la serie M), se requiere Rosetta 2 para grpc-tools.

## Prueba de la instalación

Para probar tu instalación, consulta el [Crear tu primer proyecto de .NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app) para obtener más información.


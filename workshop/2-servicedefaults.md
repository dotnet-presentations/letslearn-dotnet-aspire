# Service Defaults aka Smart Defaults

## Introduction
.NET Aspire provides a set of smart defaults for services that are commonly used in .NET applications. These defaults are designed to help you get started quickly and provide a consistent experience across different types of applications. This includes:

- Telemetry: Metrics, Tracing, Logging
- Resiliency
- Health Checks
- Service Discovery

## Create Service Defaults Project

### Visual Studio & Visual Studio Code

1. Add a new project to the solution called `ServiceDefaults`:

	- Right-click on the solution and select `Add` > `New Project`.
	- Select the `.NET Aspire Service Defaults` project template.
	- Name the project `ServiceDefaults`.
	- Click `Next` > `Create`.

	*Visual Studio*
	![Visual Studio dialog to add a service defaults project](./media/vs-add-servicedefaults.png)]

	*Visual Studio Code*
	![Visual Studio Code dialog to add a service defaults project](./media/vsc-add-servicedefaults.png)]


### Command Line

1. Create a new project using the `dotnet new aspire-servicedefaults` command:

	```bash
	dotnet new aspire-servicedefaults -n ServiceDefaults
	```

## Configure Service Defaults

1. Add a reference to the `ServiceDefaults` project in the `Api` and `MyWeatherHub` projects:

	- Right-click on the `Api` project and select `Add` > `Reference`.
	- Check the `ServiceDefaults` project and click `OK`.
	- - Right-click on the `Api` project and select `Add` > `Reference`.
	- Check the `MyWeatherHub` project and click `OK`.

	> Pro Tip: In Visual Studio 2022, you can drag and drop the project onto another project to add a reference.

1. In both the `Api` and `MyWeatherHub` projects, update their `Program.cs` files, adding the following line immediately after their `var builder = WebApplication.CreateBuilder(args);` line:
	
	```csharp
	builder.AddServiceDefaults();
	```
1. In both the `Api` and `MyWeatherHub` projects, update their `Program.cs` files,adding the following line immediately after their `var app = builder.Build();` line:

	```csharp
	app.MapDefaultEndpoints();
	```

## Run the application

1. Run the application using a multip-project launch configuration in Visual Studio or Visual Studio Code.

	- Visual Studio: Right click on the `MyWeatherHub` solution and go to properties. Select the `Api` and `MyWeatherHub` as startup projects, select `OK`. 
		- ![Visual Studio solution properties](./media/vs-multiproject.png)
		- Click `Start` to start and debug both projects.
	- Visual Studio Code: Run the `Api` and `MyWeatherHub` projects using the `Run and Debug` panel. We have provided a `launch.json` file with the necessary configurations to run both.
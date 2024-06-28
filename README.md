# Let's Learn .NET Aspire

Come learn all about [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/), a new cloud ready stack for building observable, production ready, distributed applications.​ .NET Aspire can be added to any application regardless of the size and scale to help you build better applications faster.​

.NET Aspire streamlines app development with:

- **Orchestration**: Built-in orchestration with a simple, yet powerful, workflow engine.Use C# and familiar APIs without a line of YAML. Easily add popular cloud services, connect them to your projects, and run locally with a single click. 
- **Service Discovery**: Automatic injection the right connection strings or network configurations and service discovery information to simplify the developer experience.
- **Components**: Built-in components for common cloud services like databases, queues, and storage. Integrated with logging, health checks, telemetry, and more.
- **Dashboard**: See live OpenTelemetry data with no configuration required. Launched by default on run, .NET Aspire's developer dashboard shows logs, environment variables, distributed traces, metrics and more to quickly verify app behavior.
- **Deployment**: manages injecting the right connection strings or network configurations and service discovery information to simplify the developer experience.
- **So Much More**: .NET Aspire is packed full of features that developers will love and help you be more productive.

Learn more about .NET Aspire with the following resources:
- [Documentation](https://learn.microsoft.com/dotnet/aspire)
- [Microsoft Learn Training Path](https://learn.microsoft.com/en-us/training/paths/dotnet-aspire/)
- [.NET Aspire Videos](https://aka.ms/aspire/videos)
- [eShop Reference Sample App](https://github.com/dotnet/eshop)
- [.NET Aspire Samples](https://learn.microsoft.com/samples/browse/?expanded=dotnet&products=dotnet-aspire)
- [.NET Aspire FAQ](https://learn.microsoft.com/dotnet/aspire/reference/aspire-faq)

## Localization

This workshop materials are available in the following languages:

- [English](./README.md)
- [한국어](./README.ko.md)

## Workshop

This .NET Aspire workshop is part of the [Let's Learn .NET](https://aka.ms/letslearndotnet) series.  This workshop is designed to help you learn about .NET Aspire and how to use it to build cloud ready applications.  This workshop is broken down into 6 modules:

1. [Setup & Installation](./workshop/1-setup.md)
1. [Service Defaults](./workhsop/2-sevicedefaults.md)
1. [Developer Dashboard & Orchestration](./workshop/3-dashboard-apphost.md)
1. [Service Discovery](./workshop/4-servicediscovery.md)
1. [Components](./workshop/5-components.md)
1. [Deployment](./workshop/6-deployment.md)

A full slide deck is available for this workshop [here](./workshop/AspireWorkshop.pptx).

The starting project for this workshop is located in the `start-with-api` folder.  This project is a simple weather API that uses the National Weather Service API to get weather data and a web frontend to display the weather data powered by Blazor.

This workshop is designed to be done in a 2 hour time frame. 

## Demo data

The data and service used for this tutorial comes from the United States National Weather Service (NWS) at https://weather.gov  We are using their OpenAPI specification to query weather forecasts.  The OpenAPI specification is [available online](https://www.weather.gov/documentation/services-web-api).  We are using only 2 methods of this API, and simplified our code to just use those methods instead of creating the entire OpenAPI client for the NWS API.

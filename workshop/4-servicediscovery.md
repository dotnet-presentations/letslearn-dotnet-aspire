# Service Discovery

.NET Aspire includes functionality for configuring service discovery at development and testing time. Service discovery functionality works by providing configuration in the format expected by the configuration-based endpoint resolver from the .NET Aspire AppHost project to the individual service projects added to the application model. 


## Service Discovery Configuration

Currently, the `MyWeatherHub` is using a static configuration to connect to the `Api`. This is not ideal for several reasons including:

- The port number of the `Api` service may change.
- The IP address of the `Api` service may change.
- Multiple configuration settings would need to be defined for http and https settings.
- As we add more services, the configuration would become more complex.

To address these issues, we will use the service discovery functionality provided by the .NET Aspire AppHost project. This will allow the `MyWeatherHub` service to discover the `Api` service at runtime.

1. Open the `Program.cs` file in the `AppHost` project.
1. Earlier we added orchestration to include several projects by using the `builder.AddProject` method. This returned an `IResourceBuild` that can be used to reference projects. Let's reference the `Api` project in the `MyWeatherHub` project by updating the code:

	```csharp
	var api = builder.AddProject<Projects.Api>("api");

	var web = builder.AddProject<Projects.MyWeatherHub>("MyWeatherHub")
		.WithReference(api)
		.WithExternalHttpEndpoints();
	```

1. The `WithReference` method is used to reference the `Api` project. This will allow the `MyWeatherHub` project to discover the `Api` project at runtime.
1.  If you later choose to deploy this app, you'd need the call to `WithExternalHttpEndpoints` to ensure that it's public to the outside world.

## Enabling Service Discovery in MyWeatherHub

When we added ServiceDefaults to the projects we automatically enrolled them in the service discovery system. This means that the `MyWeatherHub` project is already configured to use service discovery.

Some services expose multiple, named endpoints. Named endpoints can be resolved by specifying the endpoint name in the host portion of the HTTP request URI, following the format `scheme://_endpointName.serviceName`. For example, if a service named "basket" exposes an endpoint named "dashboard", then the URI `scheme+http://_dashboard.basket` can be used to specify this endpoint, for example:

	```csharp
	builder.Services.AddHttpClient<BasketServiceClient>(
		static client => client.BaseAddress = new("https+http://basket"));

	builder.Services.AddHttpClient<BasketServiceDashboardClient>(
		static client => client.BaseAddress = new("https+http://_dashboard.basket"));
	```

In the above example, the `BasketServiceClient` will use the default endpoint of the `basket` service, while the `BasketServiceDashboardClient` will use the `dashboard` endpoint of the `basket` service. Now, let's update the `MyWeatherHub` project to use service discovery to connect to the `Api` service.

This can be accomplished by updating the existing `WeatherEndpoint` configuration settings in the `appsettings.json`. This is convenient when enabling .NET Aspire in an existing deployed application as you can continue to use your existing configuration settings.

1. Open the `appsettings.json` file in the `MyWeatherHub` project.

1. Update the `WeatherEndpoint` configuration settings to use service discovery:

	```json
	"WeatherEndpoint": "https+http://api"
	```
1. The `WeatherEndpoint` configuration setting is now using service discovery to connect to the `Api` service.

Optionally, we can update the url to not use the `WeatherEndpoint` configuration settings. 

1. Open the `Program.cs` file in the `MyWeatherHub` project.
1. Update the `WeatherEndpoint` configuration settings to use service discovery:

	```csharp
	builder.Services.AddHttpClient<NwsManager>(
		static client => client.BaseAddress = new("https+http://api"));
	```

## Run the Application

1. Run the application by pressing `F5` or selecting the `Start Debugging` option.
1. Open the `MyWeatheApp` by selecting the endpoint in the dashboard.
1. Notice that the `MyWeatherHub` app still works and is now using service discovery to connect to the `Api` service.
1. In the dashboard click on the `Details` for the `MyWeatherHub` project. THis will bring up all of the settings that .NET Aspire configured when running the app from the App Host
1. Click on the eye icon to reveal the values and scroll to the bottom where you will see `services__api_http_0` and `services__api_https_0` configured with the correct values of the `Api` service.`

	![Service discovery settings in the dashbaord](media/dashboard-servicediscovery.png)


## Conclusion

This was just the start of what we can do with service discovery and .NET Aspire. As our application grows and we add more services, we can continue to use service discovery to connect services at runtime. This will allow us to easily scale our application and make it more resilient to changes in the environment.

## Learn More

You can learn more about advanced usage and configuration of service discovery in the [.NET Aspire Service Discovery](https://learn.microsoft.com/dotnet/aspire/service-discovery/overview) documentation.
var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Api>("api");

var web = builder.AddProject<Projects.MyWeatherHub>("MyWeatherHub")
	.WithReference(api)
	.WithExternalHttpEndpoints();

builder.Build().Run();

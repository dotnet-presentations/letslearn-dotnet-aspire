var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
	.WithRedisCommander();

var api = builder.AddProject<Projects.Api>("api")
	.WithReference(cache);

var web = builder.AddProject<Projects.MyWeatherHub>("MyWeatherHub")
	.WithReference(api);


builder.Build().Run();

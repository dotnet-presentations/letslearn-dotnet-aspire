var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
                   .WithRedisCommander();

var api = builder.AddProject<Projects.Api>("api")
                 .WithReference(cache);

var web = builder.AddProject<Projects.MyWeatherHub>("myweatherhub")
                 .WithReference(api)
                 .WithExternalHttpEndpoints();

builder.Build().Run();

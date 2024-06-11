using Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.AddRedisOutputCache("cache");

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddHttpClient<NwsManager>(client =>
{
	client.BaseAddress = new Uri("https://api.weather.gov/");
	client.DefaultRequestHeaders.Add("User-Agent", "Microsoft - .NET Aspire Demo");
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseOutputCache();

app.MapGet("/zones", async (NwsManager manager) =>
{
	var zones = await manager.GetZonesAsync();
	return TypedResults.Ok(zones);
})
.WithName("GetZones")
.CacheOutput(policy =>
{
	policy.Expire(TimeSpan.FromHours(1));
})
.WithOpenApi();

app.MapGet("/forecast/{zoneId}", async Task<Results<Ok<Forecast[]>, NotFound>> (NwsManager manager, string zoneId) =>
{
	try
	{
		var forecasts = await manager.GetForecastByZoneAsync(zoneId);
		return TypedResults.Ok(forecasts);
	} catch (HttpRequestException ex)
	{
		return TypedResults.NotFound();
	}
})
.WithName("GetForecastByZone")
.CacheOutput(policy =>
{
	policy.Expire(TimeSpan.FromMinutes(15)).SetVaryByRouteValue("zoneId");
})
.WithOpenApi();

app.Run();

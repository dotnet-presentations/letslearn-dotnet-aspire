using Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace Api
{

	public class NwsManager(HttpClient httpClient, IMemoryCache cache)
	{

		public async Task<Zone[]> GetZonesAsync()
		{

			return await cache.GetOrCreateAsync("zones", async entry =>
			{
				// To get the live zone data from NWS, uncomment the following code and comment out the return statement below
				//var response = await httpClient.GetAsync("https://api.weather.gov/zones?type=forecast");
				//response.EnsureSuccessStatusCode();
				//var content = await response.Content.ReadAsStringAsync();
				//return JsonSerializer.Deserialize<ZonesResponse>(content);

				// Deserialize the zones.json file from the wwwroot folder
				var zonesJson = File.Open("wwwroot/zones.json", FileMode.Open);
				var zones = await JsonSerializer.DeserializeAsync<ZonesResponse>(zonesJson);
				return zones.features
					.Where(f => f.properties.observationStations.Any())
					.Select(f => (Zone)f).ToArray();

			});
		}

		int forecastCount = 0;
		public async Task<Forecast[]> GetForecastByZoneAsync(string zoneId)
		{

			forecastCount++;
			if (forecastCount % 5 == 0)
			{
				throw new Exception("Random exception thrown by NwsManager.GetForecastAsync");
			}

			var response = await httpClient.GetAsync($"https://api.weather.gov/zones/Forecast/{zoneId}/forecast");
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<ForecastResponse>(content)
				.properties.periods.Select(p => (Forecast)p).ToArray();

		}

	}

}

namespace Microsoft.Extensions.DependencyInjection
{


	public static class NwsManagerExtensions
	{

		public static IServiceCollection AddNwsManager(this IServiceCollection services)
		{
			services.AddHttpClient<Api.NwsManager>(client =>
			{
				client.BaseAddress = new Uri("https://api.weather.gov/");
				client.DefaultRequestHeaders.Add("User-Agent", "Microsoft - .NET Aspire Demo");
			});

			services.AddMemoryCache();

			return services;
		}

	public static WebApplication? MapApiEndpoints(this WebApplication? app)
	{

			app.UseOutputCache();

			app.MapGet("/zones", async (Api.NwsManager manager) =>
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

			app.MapGet("/forecast/{zoneId}", async Task<Results<Ok<Api.Forecast[]>, NotFound>> (Api.NwsManager manager, string zoneId) =>
			{
				try
				{
					var forecasts = await manager.GetForecastByZoneAsync(zoneId);
					return TypedResults.Ok(forecasts);
				}
				catch (HttpRequestException ex)
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

			return app;

		}

	}


}
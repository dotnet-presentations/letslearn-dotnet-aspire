using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace MyWeatherHub.Data
{

	public class NwsManager(HttpClient httpClient, IMemoryCache cache)
	{

		public async Task<Zone[]> GetZonesAsync()
		{

			// To get the live zone data from NWS, uncomment the following code and comment out the return statement below
			//var response = await httpClient.GetAsync("https://api.weather.gov/zones?type=forecast");
			//response.EnsureSuccessStatusCode();
			//var content = await response.Content.ReadAsStringAsync();
			//return JsonSerializer.Deserialize<ZonesResponse>(content);

			return await cache.GetOrCreateAsync("zones", async entry =>
			{
				entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

				// Deserialize the zones.json file from the wwwroot folder
				using var zonesJson = File.Open("wwwroot/zones.json", FileMode.Open);
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
			services.AddHttpClient<MyWeatherHub.Data.NwsManager>(client =>
			{
				client.BaseAddress = new Uri("https://api.weather.gov/");
				client.DefaultRequestHeaders.Add("User-Agent", "Microsoft - .NET Aspire Demo");
			});

			services.AddMemoryCache();

			return services;
		}

	}

}
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace MyWeatherHub.Data;

public class NwsManager(HttpClient httpClient, IMemoryCache cache)
{

	public async Task<ZonesResponse> GetZonesAsync()
	{

		return await cache.GetOrCreateAsync("zones", async entry =>
		{

			// To get the live zone data from NWS, uncomment the following code and comment out the return statement below
			//var response = await httpClient.GetAsync("https://api.weather.gov/zones?type=forecast");
			//response.EnsureSuccessStatusCode();
			//var content = await response.Content.ReadAsStringAsync();
			//return JsonSerializer.Deserialize<ZonesResponse>(content);

			// Deserialize the zones.json file from the wwwroot folder
			var zonesJson = await File.ReadAllTextAsync("wwwroot/zones.json");
			return JsonSerializer.Deserialize<ZonesResponse>(zonesJson);

		});
	}

	int forecastCount = 0;
	public async Task<ForecastResponse> GetForecastAsync(string zoneId)
	{

		forecastCount++;
		if (forecastCount % 5 == 0)
		{
			throw new Exception("Random exception thrown by NwsManager.GetForecastAsync");
		}

		var response = await httpClient.GetAsync($"https://api.weather.gov/zones/Forecast/{zoneId}/forecast");
		response.EnsureSuccessStatusCode();
		var content = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<ForecastResponse>(content);
	}

}

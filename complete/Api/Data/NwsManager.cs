using Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Api
{

    public class NwsManager(HttpClient httpClient, IMemoryCache cache)
    {

        public async Task<Zone[]?> GetZonesAsync()
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // To get the live zone data from NWS, uncomment the following code and comment out the return statement below
            //var response = await httpClient.GetAsync("https://api.weather.gov/zones?type=forecast");
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //return JsonSerializer.Deserialize<ZonesResponse>(content, options);

            return await cache.GetOrCreateAsync("zones", async entry =>
            {
                if (entry is null)
                    return [];

                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

                // Deserialize the zones.json file from the wwwroot folder
                var zonesJson = File.Open("wwwroot/zones.json", FileMode.Open);
                if (zonesJson is null)
                    return [];

                var zones = await JsonSerializer.DeserializeAsync<ZonesResponse>(zonesJson, options);

                return zones?.Features
                            ?.Where(f => f.Properties?.ObservationStations?.Count > 0)
                            .Select(f => (Zone)f)
                            .ToArray() ?? [];
            });

        }

        static int forecastCount = 0;
        public async Task<Forecast[]> GetForecastByZoneAsync(string zoneId)
        {

            forecastCount++;
            if (forecastCount % 5 == 0)
            {
                throw new Exception("Random exception thrown by NwsManager.GetForecastAsync");
            }

            var response = await httpClient.GetAsync($"https://api.weather.gov/zones/forecast/{zoneId}/forecast");
            response.EnsureSuccessStatusCode();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var forecasts = await response.Content.ReadFromJsonAsync<ForecastResponse>(options);
            return forecasts?.Properties?.Periods?.Select(p => (Forecast)p).ToArray() ?? [];
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
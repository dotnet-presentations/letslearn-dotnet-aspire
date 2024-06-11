using System.Text.Json.Serialization;

namespace MyWeatherHub.Data;

public class ZonesResponse
{
	public string type { get; set; }
	public Feature[] features { get; set; }

	public class Feature
	{
		public string id { get; set; }
		public string type { get; set; }
		public Properties properties { get; set; }

		public static explicit operator Zone(Feature feature)
			=> new Zone(feature.properties.key, feature.properties.name, feature.properties.state);

	}

	public class Properties
	{
		public string geometry { get; set; }

		[JsonPropertyName("@id")]
		public string id { get; set; }

		[JsonPropertyName("id")]
		public string key { get; set; }
		public string type { get; set; }
		public string name { get; set; }
		public string state { get; set; }
		public DateTime effectiveDate { get; set; }
		public DateTime expirationDate { get; set; }
		public string[] cwa { get; set; }
		public string[] forecastOffices { get; set; }
		public string[] timeZone { get; set; }
		public string[] observationStations { get; set; }
		public string radarStation { get; set; }
	}
}

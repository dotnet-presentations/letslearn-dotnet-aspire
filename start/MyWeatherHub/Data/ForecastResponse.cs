namespace MyWeatherHub.Data;

public class ForecastResponse
{
    public string id { get; set; }
    public string type { get; set; }
    public Properties properties { get; set; }

    public class Properties
    {
        public string geometry { get; set; }
        public string zone { get; set; }
        public DateTime updated { get; set; }
        public Period[] periods { get; set; }
    }

    public class Period
    {
        public int number { get; set; }
        public string name { get; set; }
        public string detailedForecast { get; set; }

		public static explicit operator Forecast(Period period)
			=> new Forecast(period.name, period.detailedForecast);

	}
}

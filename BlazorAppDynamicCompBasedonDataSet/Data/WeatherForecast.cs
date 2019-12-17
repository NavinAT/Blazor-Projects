using System;

namespace BlazorAppDynamicCompBasedonDataSet.Data
{
	public class WeatherForecast
	{
		#region Properties
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int) (this.TemperatureC / 0.5556);

		public string Summary { get; set; }
		#endregion
	}
}
﻿using System;

namespace BlazorDemoRightOne.Shared
{
	public class WeatherForecast
	{
		#region Properties
		public DateTime Date { get; set; }
		public int TemperatureC { get; set; }
		public string Summary { get; set; }
		public int TemperatureF => 32 + (int) (this.TemperatureC / 0.5556);
		#endregion
	}
}
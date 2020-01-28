using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BlazorKestrelSample
{
	public class Program
	{
		#region Publics
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
		#endregion
	}
}
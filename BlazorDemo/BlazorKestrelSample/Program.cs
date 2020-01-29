using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BlazorKestrelSample
{
	public class Program
	{
		#region Publics
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();

			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

		// Configuring port number via code

		//public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
		//	WebHost.CreateDefaultBuilder(args)
		//	       .UseUrls("http://localhost:6000")
		//	       .UseKestrel()
		//	       .UseStartup<Startup>();

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			IConfigurationRoot configRoot = new ConfigurationBuilder()
			                                .SetBasePath(Directory.GetCurrentDirectory())
			                                .AddJsonFile("appsettings.json", optional: false)
			                                .Build();

			IWebHostBuilder webHost = WebHost.CreateDefaultBuilder(args)
			                                 .UseUrls($"http://localhost:{configRoot.GetValue<int>("Host:Port")}")
			                                 .UseKestrel()
			                                 .UseStartup<Startup>();

			return webHost;
		}
		#endregion
	}
}
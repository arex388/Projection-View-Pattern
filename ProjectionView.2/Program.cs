using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ProjectionView._2 {
	public class Program {
		public static async Task Main(
			string[] args) => await WebHost.CreateDefaultBuilder(args)
										   .UseStartup<Startup>()
										   .Build()
										   .RunAsync();
	}
}
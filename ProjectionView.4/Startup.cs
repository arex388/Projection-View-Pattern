using Arex388.AspNetCore;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectionView.Data;

namespace ProjectionView._4 {
	public class Startup {
		public IConfiguration Configuration { get; }
		public IHostingEnvironment Environment { get; }

		public Startup(
			IConfiguration configuration,
			IHostingEnvironment environment) {
			Configuration = configuration;
			Environment = environment;
		}

		public void ConfigureServices(
			IServiceCollection services) {
			services.AddMvc().AddViewOptions(
				o => {
					o.HtmlHelperOptions.IdAttributeDotReplacement = ".";
					o.HtmlHelperOptions.ClientValidationEnabled = false;
				}).SetCompatibilityVersion(CompatibilityVersion.Latest);
			services.AddMediatR();
			services.AddAutoMapper();
			services.AddDbContext<ProjectionViewContext>(
				o => {
					o.UseSqlServer(Configuration.GetConnectionString("DevelopmentConnection"));
				});
			services.AddMiniProfiler().AddEntityFramework();
			services.AddFeatures();

			services.Configure<KestrelServerOptions>(
				o => {
					o.AddServerHeader = false;
				});
			services.Configure<RouteOptions>(
				o => {
					o.LowercaseUrls = true;
				});
		}

		public void Configure(
			IApplicationBuilder app) {
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseMiniProfiler();

			app.UseMvc(
				r => {
					r.MapRoute(
						"2",
						"{controller}/{id:int}/{action=Edit}",
						null,
						new {
							action = "Edit"
						}
					);

					r.MapRoute(
						"1",
						"{controller}/{action=List}",
						null,
						new {
							controller = "Employees|Jobs"
						}
					);

					r.MapRoute(
						"0",
						"{action=Default}",
						new {
							controller = "Dashboard"
						}
					);
				});
		}
	}
}

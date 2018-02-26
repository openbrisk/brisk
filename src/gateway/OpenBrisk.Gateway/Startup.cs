using k8s;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using OpenBrisk.Gateway.Services;

namespace OpenBrisk.Gateway
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.Configure<>();

			services.AddSingleton<IKubernetes>(serviceProvider =>
			{
				KubernetesClientConfiguration config = KubernetesClientConfiguration.InClusterConfig();
				return new Kubernetes(config);
			});
			services.AddSingleton<IKubernetesService, KubernetesService>();

			services.AddMvc()
					.AddJsonOptions(setup =>
					{
						setup.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = false });
					}
			);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}

using IdentityServer4.Core.Configuration;

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

using System.IO;
using System.Security.Cryptography.X509Certificates;

using Theo.RnD.Aurelia.OAuthIdentityServer.IdentityConfigs;
using Theo.RnD.Aurelia.OAuthIdentityServer.UI;
using Theo.RnD.Aurelia.OAuthIdentityServer.UI.Login;

namespace Theo.RnD.Aurelia.OAuthIdentityServer
{
    public class Startup
    {
        private readonly IApplicationEnvironment _AppEnvironment;

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnvironment)
        {
            _AppEnvironment = appEnvironment;
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            var policy = new Microsoft.AspNet.Cors.Infrastructure.CorsPolicy();

            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));

            var cert = new X509Certificate2(Path.Combine(_AppEnvironment.ApplicationBasePath, "Theo.RnD.Cert.pfx"), "theornd", X509KeyStorageFlags.MachineKeySet);

            var builder = services.AddIdentityServer(options => {
                options.SigningCertificate = cert;
                options.Endpoints.EnableEndSessionEndpoint = true;
                options.AuthenticationOptions = new AuthenticationOptions
                {
                    EnableSignOutPrompt = false
                };
            });
            builder.Services.AddLogging();
            builder.AddInMemoryClients(Clients.Get());
            builder.AddInMemoryScopes(Scopes.Get());
            builder.AddInMemoryUsers(Users.Get());


            // Add framework services.
            services.AddMvc()
                        .AddRazorOptions(razor => { razor.ViewLocationExpanders.Add(new CustomViewLocationExpander()); }
                );
            services.AddTransient<LoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("corsGlobalPolicy");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler();

           
            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

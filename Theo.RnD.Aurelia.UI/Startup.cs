using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.IdentityModel.Tokens.Jwt;

namespace Theo.RnD.Aurelia.UI
{
    public class Startup
    {
        private readonly IApplicationEnvironment _AppEnvironment;

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnvironment)
        {
            // Set up configuration sources. 

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            _AppEnvironment = appEnvironment;
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            var cert = new X509Certificate2(Path.Combine(_AppEnvironment.ApplicationBasePath, "Theo.RnD.Cert.pfx"), "theornd", X509KeyStorageFlags.MachineKeySet);

            services.AddDataProtection();

            var policy = new Microsoft.AspNet.Cors.Infrastructure.CorsPolicy();

            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            
            services.AddMvc();

            // Add application services.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseCors("corsGlobalPolicy");

            app.UseStaticFiles();

            app.UseCookieAuthentication(options =>
            {
                options.AuthenticationScheme = "cookies";
                options.AutomaticAuthenticate = true;
            });

            // *** This will enable the Authentication from the MVC aapplication *** START
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //app.UseIdentityServerAuthentication(options =>
            //{
            //    options.Authority = "http://localhost:10011/";
            //    options.ScopeName = "aurelia.backend.datarecords";
            //    options.ScopeSecret = "aurelia.backend.datarecords";
            //    options.AutomaticAuthenticate = true;
            //    options.AutomaticChallenge = true;
            //});

            //app.UseOpenIdConnectAuthentication(options =>
            //{
            //    options.AuthenticationScheme = "oidc";
            //    options.SignInScheme = "cookies";
            //    options.AutomaticChallenge = true;

            //    options.Authority = "http://localhost:10011/";
            //    options.RequireHttpsMetadata = false;

            //    options.ClientId = "aurelia.ui";
            //    options.ClientSecret = "aurelia.ui";
            //    //options.ResponseType = "id_token token";


            //    //options.Scope.Add("profile");
            //    //options.Scope.Add("email");
            //    //options.Scope.Add("roles");
            //    options.Scope.Add("aurelia.backend.datarecords");

            //    //options.TokenValidationParameters.NameClaimType = "name";
            //    //options.TokenValidationParameters.RoleClaimType = "role";
            //});
            // *** This will enable the Authentication from the MVC aapplication *** END

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

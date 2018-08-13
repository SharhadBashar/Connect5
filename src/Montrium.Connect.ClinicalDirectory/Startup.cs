using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Montrium.Connect.ClinicalDirectory.Repositories;
using Montrium.Connect.ClinicalDirectory.Services;

namespace Montrium.Connect.ClinicalDirectory
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<ClinicalDirectorySettings>(this.Configuration);
            services.AddScoped<IBaseGraphRepository, BaseGraphRepository>();
            services.AddScoped<IStudyService, StudyService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProcessZoneService, ProcessZoneService>();
            services.AddScoped<IDocumentService, DocumentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThesisPrototype.Calculators;
using ThesisPrototype.Handlers;
using ThesisPrototype.Retrievers;
using ThesisPrototype.Seeders;

namespace ThesisPrototype
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ASP.NET / EF Services
            services.AddDbContext<PrototypeContext>();

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddIdentity<User, IdentityRole>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<PrototypeContext>()
                    .AddDefaultTokenProviders();

            services.AddMvc();

            // Adding custom services
            services.AddSingleton(typeof(ImportHandler), typeof(ImportHandler));

            services.AddSingleton(typeof(KpiCalculatorFactory), typeof(KpiCalculatorFactory));
            services.AddSingleton(typeof(KpiCalculationHandler), typeof(KpiCalculationHandler));

            services.AddSingleton(typeof(GraphHandler), typeof(GraphHandler));

            services.AddSingleton(typeof(SensorValuesRowRetriever), typeof(SensorValuesRowRetriever));
            services.AddSingleton(typeof(KpiValueRetriever), typeof(KpiValueRetriever));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                              UserManager<User> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseFileServer();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}");
            });

            UserSeeder.SeedUsers(userManager);
            KpiSeeder.SeedKpis();
        }
    }
}

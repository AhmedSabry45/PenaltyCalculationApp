using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.FactoryPattern;
using Microsoft.Extensions.Hosting;
using PenaltyCalculation.Web.Data;
using PenaltyCalculation.Web.Services;
using PenaltyCalculation.Web.Services.Abstract;
using PenaltyCalculation.Web.Services.Concrete;

namespace PenaltyCalculation.Web
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICountryRepository, CountryRepository>();

            services.Add(typeof(IPenaltyCalculationService), typeof(TurkeyPenaltyCalculationService), CountryEnum.TR.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(UnitedArabEmiratesPenaltyCalculationService), CountryEnum.AE.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(ChinaPenaltyCalculationService), CountryEnum.TW.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(GermanPenaltyCalculationService), CountryEnum.DE.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(DenmarkPenaltyCalculationService), CountryEnum.DK.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(UnitedStatePenaltyCalculationService), CountryEnum.US.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(FrancePenaltyCalculationService), CountryEnum.FR.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(ItalyPenaltyCalculationService), CountryEnum.IT.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(JapanPenaltyCalculationService), CountryEnum.JP.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(KoreaPenaltyCalculationService), CountryEnum.KR.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(RussiaPenaltyCalculationService), CountryEnum.RU.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(IndiaPenaltyCalculationService), CountryEnum.IN.GetName(), ServiceLifetime.Transient);
            services.Add(typeof(IPenaltyCalculationService), typeof(EgyptPenaltyCalculationService), CountryEnum.EG.GetName(), ServiceLifetime.Transient);



            services.AddSingleton<IPenaltyCalculationServiceFactoryPatternResolver, PenaltyCalculationServiceFactoryPatternResolver>();

            services.AddSingleton<IPenaltyCalculationProcessor, PenaltyCalculationProcessor>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

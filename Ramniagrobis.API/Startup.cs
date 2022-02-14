using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Raminagrobis;

namespace Ramniagrobis.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ramniagrobis.API", Version = "v1" });
            });
            services.AddSingleton(typeof(IFournisseurService), new FournisseurService());
            services.AddSingleton(typeof(IAdherentService), new AdherentService());
            services.AddSingleton(typeof(IReferenceService), new ReferenceService());
            services.AddSingleton(typeof(IPanier_AdherentService), new Panier_AdherentService());
            services.AddSingleton(typeof(IPanier_Adherent_DetailsService), new Panier_Adherent_DetailsService());
            services.AddSingleton(typeof(IPanier_GlobalService), new Panier_GlobalService());
            services.AddSingleton(typeof(IOffres_FournisseurService), new Offres_FournisseursService());
            services.AddSingleton(typeof(IReference_detailsService), new Reference_detailsService());
            services.AddSingleton(typeof(IPanier_Global_DetailsService), new Panier_Global_DetailsService());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ramniagrobis.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

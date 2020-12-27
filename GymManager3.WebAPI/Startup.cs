using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.WebAPI.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using GymManager3.WebAPI.Services;
using AutoMapper;
using GymManager3.WebAPI.Filters;
using Microsoft.AspNetCore.Authentication;
using GymManager3.WebAPI.Security;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;




namespace GymManager3.WebAPI
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
            
            services.AddMvc(x=>x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(typeof(Startup));
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //    c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
            //    c.DocumentFilter<BasicAuthDocumentFilter>();
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GymManager3 API", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });

            // var connection = @"Server=.;Database=GymManager1;Trusted_Connection=True;";
            // Docker:
             services.AddDbContext<GymManager1Context>(opt => opt.UseSqlServer(Configuration["CONNECTION_STRING"]));
            // Local:
           // services.AddDbContext<GymManager1Context>(opt => opt.UseSqlServer("Server=.;Database=GymManager1;Trusted_Connection=True;"));

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IPolaznikService, PolaznikService>();
            services.AddScoped<IUplataService, UplataService>();
            services.AddScoped<IGradService, GradService>();
            services.AddScoped<IAdministracijaService, AdministracijaService>();
            services.AddScoped<ITreneriService, TreneriService>();
            services.AddScoped<ITreninziService, TreninziService>();
            services.AddScoped<IVrstaSubskripcijeService, VrstaSubskripcijeService>();
            services.AddScoped<IVrstaTreningaService, VrstaTreningaService>();
            services.AddScoped<IUlogaService, UlogaService>();
            services.AddScoped<ITerminService, TerminService>();
            services.AddScoped<IUplateService, UplateService>();
            services.AddScoped<IKorisniciUlogeService, KorisniciUlogeService>();
            services.AddScoped<IRezervacijaTreningaService, RezervacijaTreningaService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISubskripcijaService, SubskripcijaService>();
            services.AddScoped<IAuthTrenerService, AuthTrenerService>();
            services.AddScoped<IRezervacijaTreneraService, RezervacijaTreneraService>();
            services.AddScoped<ISlobodniTerminiService, SlobodniTerminiService>();
            services.AddScoped<IRecommendService, RecommendService>();
            services.AddScoped<IOcjeneService, OcjeneService>();
            services.AddScoped<ITrenerService, TrenerService>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

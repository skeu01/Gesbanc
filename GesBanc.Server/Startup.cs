using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gesbanc.Business.Contracts;
using Gesbanc.Business.Services;
using Gesbanc.Common.Helpers;
using Gesbanc.Infrastructure.Context;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GesBanc.Server
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            AddCorsConfig(services);
            AddDIConfig(services);
            AddJwtTokenConfig(services);
            AddSwagger(services);

            services.AddDbContext<GesbancContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("GesbancConnection")));
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

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");

                c.DocumentTitle = "Title Documentation";
                c.DocExpansion(DocExpansion.None);
            });

            
            
        }

        /// <summary>
        /// Add CORS configuration
        /// </summary>
        /// <param name="services">IServiceCollection object</param>
        private void AddCorsConfig(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("cors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
        }

        /// <summary>
        /// Add DI for repos and services
        /// </summary>
        /// <param name="services">IServiceCollection object</param>
        private void AddDIConfig(IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ISecurityRepository), typeof(SecurityRepository));
            services.AddScoped(typeof(IEntidadRepository), typeof(EntidadRepository));

            //Services
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(ISecurityService), typeof(SecurityService));
            services.AddScoped(typeof(IEntidadService), typeof(EntidadService));

        }

        /// <summary>
        /// Add jwt token configuration
        /// </summary>
        /// <param name="services">IServiceCollection object</param>
        private void AddJwtTokenConfig(IServiceCollection services)
        {
            services.Configure<TokenManagement>(Configuration.GetSection("AppSettings"));
            var token = Configuration.GetSection("AppSettings").Get<TokenManagement>();
            var secret = Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }); 
        }

        /// <summary>
        /// Add swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="services">IServiceCollection object</param>
        private void AddSwagger(IServiceCollection services)
        {

            // Register the Swagger generator, defining 1 or more Swagger documents
            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = "Main API v1.0", Version = "v1.0" });

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });
        }
    }

    
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//***
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using FgOnlinePortal.Core.Utilities.Extensions.Connection;
using FgOnlinePortal.DataLayer.Repository;
using FgOnlinePortal.Core.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FgOnlinePortal.Core.Services.Implementations;

namespace FgOnlinePortal.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IConfiguration>(
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json")
                    .Build()
            );
            #region AddDbContext
            services.AddApplicationDbContext(Configuration);
            services.AddScoped(typeof(IGenericRepository<>),
                typeof(GenericRepository<>)
                );
            #endregion

            #region IOC
            services.AddScoped<IPaymentGatewayService, PaymentGatewayService>();
            #endregion


            #region Authentication

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44373",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("FgOnlinePortalJwtBearer"))
                    };
                });

            #endregion


            //#region CORS

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("EnableCors", builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //            .AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .AllowCredentials()
            //            .Build();
            //    });
            //});

            //#endregion

            /*services.AddDbContext<FgOnlinePortalDbContext>(options =>
            {
                var connectionString = "ConnectionStrings:FgOnlinePortalConnection:Development";
                options.UseSqlServer(Configuration[connectionString]);
            });*/


            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors("EnableCors");
            //used the file/picture
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

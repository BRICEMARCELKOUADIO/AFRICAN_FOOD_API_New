using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using AFRICAN_FOOD_API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.HttpOverrides;

namespace asp_core_api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions =>
                        {
                            // ReSharper disable once AssignNullToNotNullAttribute
                            sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                        });
            });


            //options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            //});


            //services.AddDbContext<AppDbContext>(options =>
            //{

            //    options.UseSqlServer("Server=tcp:clouddatabaseserver.database.windows.net,1433;Initial Catalog=africanfooddb;Persist Security Info=False;User ID=philippe;Password=mXJS6)i~uWpX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", 
            //        builder => { builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null); }
            //     );

            //    // options.UseInMemoryDatabase("AfricanFood");

            //    options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            //});

            services.AddMvc();

            //services.AddSwaggerGen(options =>
            //{
            //    options.DescribeAllEnumsAsStrings();
            //    options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            //    {
            //        Title = "Bethany's Pie Shop - Catalog API",
            //        Version = "v1",
            //        Description = "The Catalog HTTP API"
            //    });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }

            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            //});
            //app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

        }
    }
}


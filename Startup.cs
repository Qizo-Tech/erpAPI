using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using qizoErpApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace qizoErpWebApiApp
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
          
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            //            services.AddMvc(option => option.EnableEndpointRouting = false)
            //.SetCompatibilityVersion(CompatibilityVersion.Version_3_0).
            //AddJsonOptions(opt => opt.JsonSerializerOptions.ref.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddDbContext<AppDBContext>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddControllers();


            // Add Cors  (to resolve cross origin error)
            services.AddCors(options => 
            { options.AddPolicy("EnableCORS", Builder => 
            {
                Builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                 });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Add Cors (to resolve cross origin error)
            app.UseCors("EnableCORS");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

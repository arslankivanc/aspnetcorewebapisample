using Eticaret.Business.Abstract;
using Eticaret.Business.Concrete;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddSwaggerDocument(opt=> {
                opt.PostProcess=(opt =>
                {
                    opt.Info.Title = "Product API";
                    opt.Info.Version = "1.0.0";
                    opt.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Kývanç Arslan",
                        Email = "abcde@gmail.com"
                    };
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
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

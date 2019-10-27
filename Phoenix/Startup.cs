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
using Phoenix.Services.Interfaces;
using Phoenix.Leviathan.Services;
using Phoenix.Filters;
using Phoenix.Repositories.Interfaces;
using Phoenix.Repositories;

namespace Phoenix
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
            services.AddSingleton<IEmployeeRepo, EmployeeJsonRepo>();
            services.AddSingleton<ICustomerRepo, CustomerJsonRepo>();
            services.AddSingleton<IOrderRepo, OrderJsonRepo>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddScoped<PheonixAuthFilter>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

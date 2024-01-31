using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RESTArchExample.Common.DTO;
using RESTArchExample.Common.Interfaces;
using RESTArchExample.LogicLayer;
using RESTArchExample.ServiceLayer.controllers;
using RESTArchExample.ServiceLayer.handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.ServiceLayer.config
{
    public class InventoryManagementStartup
    {
        #region Constructors

        public InventoryManagementStartup()
        {
            
        }

        #endregion

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<InventoryManagementLogic>(_ => new InventoryManagementLogic());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //Add One line per handler
            services.AddTransient<IRequestHandler<CreateCarModelReqDTO, CreateCarModelRespDTO>, CarModelCreatedEventHandler>();
            services.AddTransient<IRequestHandler<GetCarModelReqDTO, GetCarModelRespDTO>, GetCarModelsEventHandler>();


            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Esto configura los endpoints de los controladores.
            });
        }

    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTArchExample.ServiceLayer.config;
using Microsoft.Extensions.Hosting;
using RESTArchExample.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using RESTArchExample.Common.Util;

namespace RESTArchExample.ServiceLayer
{
    public class InventoryManagementService
    {

        #region Protected Attributes

        protected string InventoryMgmtURL { get; set; }

      

        #endregion

        #region Constructors


        public InventoryManagementService()
        {
            Logger.Instance.DoLog("Initializing InventoryManagementService...", MessageType.Information);


        }

        #endregion

        #region Public Methods

        public void Run()
        {
            var hostBuilder = Host.CreateDefaultBuilder(new string[] { });

            hostBuilder.ConfigureWebHostDefaults(delegate (IWebHostBuilder webBuilder)
            {
                webBuilder.UseKestrel();
                webBuilder.UseUrls(ConfigParamManager.Instance.GetConfig("InventoryManagementSettings", "BaseUrl"));
                webBuilder.UseStartup<InventoryManagementStartup>();
            });

            hostBuilder.Build().Run();

        }

        #endregion
    }

}

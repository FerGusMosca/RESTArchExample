
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;
using RESTArchExample.Common.Interfaces;
using RESTArchExample.Common.Util;
using RESTArchExample.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            
            try
            {

               


                IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json",
                       optional: true,
                       reloadOnChange: true).Build();

                Logger.Initiate("DEBUG");
                ConfigParamManager.Initiate(configuration);
                Logger.Instance.DoLog($"Initializing RESTArchExample....",MessageType.Information);
                InventoryManagementService svc = new InventoryManagementService();
                svc.Run();

                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Logger.Instance.DoLog($"CRITICAL ERROR Running App :{ex.Message}", MessageType.Error);


            }
        }
    }
}

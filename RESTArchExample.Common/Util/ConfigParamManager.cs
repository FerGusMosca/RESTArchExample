
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.Common.Util
{
    public class ConfigParamManager
    {
        #region Protected Static Attributes

        protected static IConfiguration GlobalConfiguration { get; set; }

        protected IConfiguration LocalConfiguration { get; set; }

        #endregion

        #region Constructors


        protected ConfigParamManager(IConfiguration pLocalConfiguration) 
        {
            LocalConfiguration= pLocalConfiguration;
        }

        #endregion


        #region Public Static Methods


        public static void Initiate(IConfiguration pConfiguration)
        {


            GlobalConfiguration = pConfiguration;
        }


        #endregion

        #region Protected Static Attributes

        protected static ConfigParamManager _Instance;
        public static ConfigParamManager Instance
        {
            get {

                if (_Instance == null)
                    _Instance = new ConfigParamManager(GlobalConfiguration);


                return _Instance;
            }

        }

        #endregion

        #region Public Attributes


        public string GetConfig(string section, string key)
        {

            //TODO validate that the section /key exist
            return LocalConfiguration.GetSection(section)?[key];


        }

        #endregion
    }
}

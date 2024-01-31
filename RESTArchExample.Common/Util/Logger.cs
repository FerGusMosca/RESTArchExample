using RESTArchExample.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.Common.Util
{
    public class Logger: ILogger
    {
        #region Protected Static Consts

        protected static string _INFO = "INFO";
        protected static string _DEBUG = "DEBUG";

        #endregion

        #region Protected Attributes

        protected static string DebugLevel { get; set; }

        #endregion

        #region  Static Attributes

     

        protected static Logger _Instance { get; set; }

        public static Logger Instance
        {
            get {

                if (_Instance == null)
                    _Instance = new Logger(DebugLevel);

                return _Instance;
            
            }
        
        }

        #endregion

        #region Constructors

        private Logger(string pDebugLevel)
        {
            DebugLevel = pDebugLevel;

        }

        #endregion

        #region Public Static Methods

        public static void Initiate(string pDegugLevel)
        {
            DebugLevel = pDegugLevel;
        }


        //This should be logged, but we will write it on the screen for simplicity
        public void DoLog(string message, MessageType type)
        {
            if (type == MessageType.Debug && DebugLevel != _DEBUG)
                return;

            if (type == MessageType.Debug)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                //Logger.Debug(msg, type);
            }
            else if (type == MessageType.Information)
            {
                //Logger.Debug(msg, type);
            }
            else if (type == MessageType.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Logger.Alert(msg, type);
            }
            else if (type == MessageType.EndLog)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Logger.Debug(msg, type);
            }
            else if (type == MessageType.Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Logger.Debug(msg, type);
            }

            Console.WriteLine(message);

            Console.ResetColor();
        }

        #endregion
    }
}

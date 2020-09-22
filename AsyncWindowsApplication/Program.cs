using AsyncWindowsApplication.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncWindowsApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Getting connectionString from App.config file
            var connectionString = ConfigurationManager.ConnectionStrings["BlaBlaMart"].ConnectionString;

            #region SerilogConfig
            var logPath = ConfigurationManager.AppSettings["LogPath"];

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Async(a => a.File(logPath, rollingInterval: RollingInterval.Day))
                .CreateLogger(); 
            #endregion

            Log.Logger.Information("Application was started");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(new DisconnectedUserRepository(connectionString)));
        }
    }
}

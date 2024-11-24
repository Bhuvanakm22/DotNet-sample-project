using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string[] CommandLineArgs;

        void app_Startup(object sender, StartupEventArgs e)
        {
            // If no command line arguments were provided, don't process them 
            if (e.Args.Length == 0) return;

            if (e.Args.Length > 0)
            {
                CommandLineArgs = e.Args;
            }
        }

    }
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigurationHelper()
        {
            // Build configuration
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string GetConnectionString(string name)
        {
            string ConnString= Configuration.GetSection("ConnectionStrings")[name].ToString();
            if (ConnString.Length > 0)
            {
                return ConnString;//Configuration.GetConnectionString(name);
            }
            else
                return null;//"No connection string. Please set it on AppSettings.json";
        }
        public static string GetAppSetting(string name)
        {
            string GetAppSetting = Configuration.GetSection("Flag")[name].ToString();
             return GetAppSetting;
        }
    }

}

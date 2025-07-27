using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebGame.Persistance.Configuration
{
    static class ConnectionConfiguration
    {
        static public string? ConnectionString
        {
            get
            {
                ConfigurationManager configuration = new();
                var devPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "../../Presentation/WebGame.API/appsettings.json");
                if (File.Exists(devPath))
                {
                    configuration.SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),
                        "../../Presentation/WebGame.API")));
                }
                else
                {
                    configuration.SetBasePath(Directory.GetCurrentDirectory());
                }

                configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                return configuration.GetConnectionString("DatabaseConnection");
            }
        }
    }
}

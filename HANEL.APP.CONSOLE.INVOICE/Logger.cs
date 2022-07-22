using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace HANEL.APP.CONSOLE.INVOICE
{
    public abstract class Logger<T>
    {
        public ILogger<T> Log;

        public Logger()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    //.AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });

            Log = loggerFactory.CreateLogger<T>();
        }

        protected virtual void ErrorLog(string message, params object[] args) => Log.LogError(message, args);

    }
}

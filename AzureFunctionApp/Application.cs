using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AzureFunctionApp
{
    public class Application : IApplication
    {
        private readonly ILogger<Application> _logger;

        public Application(ILogger<Application> logger)
        {
            _logger = logger;
        }
        public string ProcessData()
        {
            Console.WriteLine("application triggered");
            _logger.LogInformation("application triggered!");
            return "krati";
        }
    }
}

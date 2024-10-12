using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Services.Interfaces;

namespace WeatherMonitor.Services;

public class ConsoleOutputService : IOutputService
{
    public void Output(string message)
    {
        Console.WriteLine(message);
    }
}

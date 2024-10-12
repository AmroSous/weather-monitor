using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.UI;

namespace WeatherMonitor.Services;

public class ConsoleOutputService : IOutputService
{
    public void Output(string message)
    {
        Console.WriteLine();
        DisplayHelper.Print("[Bot Output]: ", ConsoleColor.DarkCyan);
        DisplayHelper.PrintLine("message", ConsoleColor.DarkGreen);
        Console.WriteLine();
    }
}

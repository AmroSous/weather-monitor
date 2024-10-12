using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Models;

public class WeatherData(string location, double temperature, double humidity)
{
    public string Location { get; init; } = location;

    public double Temperature { get; init; } = temperature;

    public double Humidity { get; init;} = humidity;
}

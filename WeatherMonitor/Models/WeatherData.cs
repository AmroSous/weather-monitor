using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Models;

public class WeatherData
{
    public string Location { get; set; } = string.Empty;

    public double Temperature { get; set; } = 0;

    public double Humidity { get; set;} = 0;
}

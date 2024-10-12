using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;

namespace WeatherMonitor.Services.Interfaces;

public interface IWeatherDataParser
{
    WeatherData? Parse(string input);
}

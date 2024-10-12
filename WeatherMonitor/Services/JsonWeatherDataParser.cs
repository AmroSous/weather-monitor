using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherMonitor.Models;
using WeatherMonitor.Services.Interfaces;

namespace WeatherMonitor.Services;

public class JsonWeatherDataParser : IWeatherDataParser
{

    public WeatherData? Parse(string input)
    {
        var parsedObject = JsonSerializer.Deserialize<WeatherData>(input);
        return parsedObject;
    }
}

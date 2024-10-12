using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;
using WeatherMonitor.Services.Interfaces;

namespace WeatherMonitor.Services;

public class XmlWeatherDataParser : IWeatherDataParser
{
    public WeatherData? Parse(string input)
    {
        System.Xml.Serialization.XmlSerializer ser = new(typeof(WeatherData));
        using StringReader sr = new(input);
        return (WeatherData?)ser.Deserialize(sr);
    }
}

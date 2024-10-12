using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Services.Interfaces;

namespace WeatherMonitor.Services;

public class WeatherDataParserResolver(IEnumerable<IWeatherDataParser> parsers)
{
    private readonly Dictionary<string, IWeatherDataParser> _parsers = 
        parsers.ToDictionary(p => p.GetType().Name, p => p);

    /// <summary>
    /// return the appropriate parser pased on format.
    /// </summary>
    /// <exception cref="NotSupportedException"></exception>
    public IWeatherDataParser GetParser(WeatherDataFormat format)
    {
        return format switch
        {
            WeatherDataFormat.JSON => _parsers["JsonWeatherDataParser"],
            WeatherDataFormat.XML => _parsers["XmlWeatherDataParser"],
            _ => throw new NotSupportedException($"Format '{format}' is not supported."),
        };
    }
}

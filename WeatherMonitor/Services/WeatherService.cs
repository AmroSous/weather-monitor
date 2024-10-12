using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.WeatherBots;

namespace WeatherMonitor.Services;

public class WeatherService(
    IEnumerable<IObserverBot> bots,
    WeatherDataParserResolver weatherDataParserResolver) : IWeatherService
{
    private readonly WeatherDataParserResolver _weatherDataParserResolver = weatherDataParserResolver;

    public List<IObserverBot> WeatherBots => bots.ToList();

    public void Analyze(string? data, WeatherDataFormat weatherDataFormat)
    {
        if (data == null) throw new InvalidOperationException("Data is invalid.");
        var parser = _weatherDataParserResolver.GetParser(weatherDataFormat);
        var weatherData = parser.Parse(data) ?? throw new InvalidDataException("weather data format is invalid.");
        NotifyBots(weatherData);
    }

    private void NotifyBots(WeatherData data)
        => WeatherBots.ForEach(bot => { bot.Update(data); });
}

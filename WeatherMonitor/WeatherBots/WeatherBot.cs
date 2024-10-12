using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;
using WeatherMonitor.Services.Interfaces;

namespace WeatherMonitor.WeatherBots;

/// <summary>
/// this abstract class holds the common logic for Bots
/// it also implements IObserverBot to enable adding Bots to weather server publisher
/// </summary>
public abstract class WeatherBot(
    BotConfiguration botConfiguration) : IObserverBot
{
    private readonly BotConfiguration _botConfiguration = botConfiguration;

    public void Update(WeatherData weatherData)
    {
        if (_botConfiguration.Enabled && ShouldActivate(weatherData))
        {
            Activate(weatherData);
        }
    }

    protected abstract bool ShouldActivate(WeatherData weatherData);

    protected abstract void Activate(WeatherData weatherData);
}

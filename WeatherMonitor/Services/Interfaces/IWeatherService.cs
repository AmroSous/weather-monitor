using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Services.Interfaces;

public interface IWeatherService
{
    List<IObserverBot> WeatherBots { get; }

    void Analyze(string? data, WeatherDataFormat weatherDataFormat);
}

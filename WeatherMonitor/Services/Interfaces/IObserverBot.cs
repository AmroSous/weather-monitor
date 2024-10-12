using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;

namespace WeatherMonitor.Services.Interfaces;

/// <summary>
/// interface to implement Observer pattern. 
/// classes implement this interface can be added to 
/// weather data publisher.
/// </summary>
public interface IObserverBot
{
    void Update(WeatherData weatherData);
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;
using WeatherMonitor.Services;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.UI;
using WeatherMonitor.WeatherBots;

namespace WeatherMonitor;

public static class Program
{
    public static void Main()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddHostedService<Application>();

        builder.Configuration.AddJsonFile("bots.settings.json", optional: false, reloadOnChange: true);
        builder.Services.Configure<WeatherBotsConfig>(builder.Configuration.GetSection("WeatherBots"));

        builder.Services.AddSingleton<IOutputService, ConsoleOutputService>();
        builder.Services.AddSingleton<IWeatherService, WeatherService>();

        builder.Services.AddSingleton<IObserverBot, SunBot>();
        builder.Services.AddSingleton<IObserverBot, SnowBot>();
        builder.Services.AddSingleton<IObserverBot, RainBot>();

        builder.Services.AddTransient<IWeatherDataParser, JsonWeatherDataParser>();
        builder.Services.AddTransient<IWeatherDataParser, XmlWeatherDataParser>();

        IHost host = builder.Build();
        host.Run();
    }
}

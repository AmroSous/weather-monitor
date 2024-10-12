using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;
using WeatherMonitor.Services;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.UI.Menus;
using WeatherMonitor.WeatherBots;

namespace WeatherMonitor.UI;

public class Application(
    IWeatherService weatherService) : IHostedService
{
    private readonly IWeatherService _weatherService = weatherService;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            try
            {
                Console.Clear();
                MainMenu? choice = DisplayHelper.PromptMenu<MainMenu>("Select operation: ");
                if (choice == null) break; // exit program

                switch(choice)
                {
                    case MainMenu.Show_all_weather_srvice_bots:
                        ShowWeatherBots();
                        break;
                    case MainMenu.Enter_weather_data:
                        ReadWeatherData();
                        break;
                    case MainMenu.Exit:
                        StopAsync(cancellationToken).Wait(cancellationToken);
                        Environment.Exit(0);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine();
        DisplayHelper.PrintLine("Applicatoin stopped.", ConsoleColor.Blue);
        Console.WriteLine();
        return Task.CompletedTask;
    }

    private void ShowWeatherBots()
    {
        Console.Clear();
        foreach (var bot in _weatherService.WeatherBots)
        {
            if (bot is WeatherBot weatherBot)
            {
                DisplayHelper.PrintLine(weatherBot.GetConfigurationString(), ConsoleColor.Green);
                Console.WriteLine();
            }
        }
        DisplayHelper.Pause("continue..");
    }

    private void ReadWeatherData()
    {
        Console.Clear();
        WeatherDataFormat? format = DisplayHelper.PromptMenu<WeatherDataFormat>("Choose input data format: ", "Back");
        if (format is null) throw new ArgumentNullException("format");
        else
        {
            Console.WriteLine();
            DisplayHelper.Print($"Enter {format} weather data: ", ConsoleColor.DarkGray);
            string? input = Console.ReadLine();
            _weatherService.Analyze(input, format.Value);
        }
        DisplayHelper.Pause("continue..");
    }
}

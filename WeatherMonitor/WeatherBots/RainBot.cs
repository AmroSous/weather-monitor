using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;
using WeatherMonitor.Services.Interfaces;

namespace WeatherMonitor.WeatherBots;

public class RainBot(
    IOptions<WeatherBotsConfig> botsConfiguration,
    IOutputService outputService) : WeatherBot(botsConfiguration.Value.RainBotConfig)
{
    private readonly BotConfiguration _botConfiguration = botsConfiguration.Value.RainBotConfig;

    private readonly IOutputService _outputService = outputService;

    protected override void Activate(WeatherData weatherData)
    {
        _outputService.Output(_botConfiguration.Message);
    }

    protected override bool ShouldActivate(WeatherData weatherData)
    {
        return weatherData.Humidity > _botConfiguration.HumidityThreshold;
    }
}

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Models;
using WeatherMonitor.Services.Interfaces;

namespace WeatherMonitor.WeatherBots;

public class SunBot(
    IOptions<WeatherBotsConfig> botsConfiguration,
    IOutputService outputService) : WeatherBot(botsConfiguration.Value.SunBotConfig)
{
    private readonly BotConfiguration _botConfiguration = botsConfiguration.Value.SunBotConfig;

    private readonly IOutputService _outputService = outputService;

    protected override void Activate(WeatherData weatherData)
    {
        _outputService.Output(_botConfiguration.Message);
    }

    protected override bool ShouldActivate(WeatherData weatherData)
    {
        return weatherData.Temperature > _botConfiguration.TemperatureThreshold;
    }
}

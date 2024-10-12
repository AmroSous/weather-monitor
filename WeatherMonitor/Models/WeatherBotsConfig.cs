using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Models;

public class WeatherBotsConfig
{
    public BotConfiguration SunBotConfig { get; set; } = new();

    public BotConfiguration RainBotConfig { get; set; } = new();

    public BotConfiguration SnowBotConfig { get; set; } = new();
}

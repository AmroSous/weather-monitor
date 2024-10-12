using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Services.Interfaces;

public interface IOutputService
{
    void Output(string message);
}

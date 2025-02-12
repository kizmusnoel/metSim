using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology_Sim
{
    internal class Weather
    {
        public string Name { get; private set; }
        public double Intensity { get; private set; }

        public DateTime Duration { get; private set; } = DateTime.MinValue;


        public Weather(string name, double intensity, int minutes)
        {
            Name = name;
            Intensity = intensity;
            Duration = Duration.AddMinutes(minutes);
        }
    }
}

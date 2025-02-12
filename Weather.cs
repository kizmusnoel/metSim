using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology_Sim
{
    internal class Weather
    {
        static Random rnd = new Random();
        public string Name { get; private set; }
        public double Intensity { get; private set; } = rnd.NextDouble() * 10;

        public DateTime Duration { get; private set; } = DateTime.MinValue.AddMinutes(rnd.Next(25, 400));


        public Weather(string name)
        {
            Name = name;
        }
        public Weather(string name, double intensity, int minutes)
        {
            Name = name;
            Intensity = intensity;
            Duration = DateTime.MinValue.AddMinutes(minutes);
        }
    }
}

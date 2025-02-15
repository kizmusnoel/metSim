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
        double _intensity = rnd.NextDouble() * 9 + 1;
        int _minutes = rnd.Next(15, 400);
        public double Intensity
        {
            get => _intensity;
            private set
            {
                if (value >= 1 && value <= 10) _intensity = value;
                else throw new Exception("Please enter a valid intensity (1-10)!");
            }
        }

        public int Minutes
        {
            get => _minutes;
            private set
            {
                if (value >= 10) _minutes = value;
                else throw new Exception("Please enter a valid duration (more than 10)!");
            }
        }


        public Weather(string name)
        {
            Name = name;
        }
        public Weather(string name, double intensity, int minutes)
        {
            Name = name;
            Intensity = intensity;
            Minutes = minutes;
        }
    }
}

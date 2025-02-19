using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology_Sim
{
    internal class Tile
    {
        public string State { get; set; } = "dry";
        double _temp = 20;
        public double Temperature
        {
            get => _temp;
            set
            {
                if (value > 50) value = 50;
                else if (value < -20) value = -20;
                _temp = value;
            }
        }
        public bool Changeable { get; set; } = false;

        public override string ToString()
        {
            if (Temperature < -10) Console.BackgroundColor = ConsoleColor.Blue;
            else switch (State)
                {
                    case "wet": Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                    case "snow": Console.BackgroundColor = ConsoleColor.White; break;
                    case "dry": Console.BackgroundColor = ConsoleColor.Green; break;
                }

            if (Temperature <= -10) return $" {Temperature} ";
            else if (Temperature < 10 && Temperature >= 0) return $"  {Temperature}  ";
            return $" {Temperature}  ";
        }
    }
}

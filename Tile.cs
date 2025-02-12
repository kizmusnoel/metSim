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
        public string Seed { get; set; } = "nothing";

        public override string ToString()
        {
            if (Seed == "nothing") Console.BackgroundColor = ConsoleColor.Black;
            else switch (State)
                {
                    case "wet": Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                    case "ruined": Console.BackgroundColor = ConsoleColor.White; break;
                    case "dry": Console.BackgroundColor = ConsoleColor.Green; break;
                }

            return " " + Convert.ToString(char.ToUpper(Seed[0])) + " ";
        }
    }
}

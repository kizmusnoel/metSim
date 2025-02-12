using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology_Sim
{
    internal class Tile
    {
        public string State { get; set; } = "dry"; // wet, ruined, seeded, dry
        public string SeededWith { get; private set; } = "N"; // corn, potato, tomato, ...

        public void Seed(string seed)
        {
            State = "seeded";
            SeededWith = seed;
        }

        public override string ToString()
        {
            switch (State) {
                case "wet": Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                case "ruined": Console.BackgroundColor = ConsoleColor.Red; break;
                case "seeded": Console.BackgroundColor = ConsoleColor.DarkRed; break;
                case "dry": Console.BackgroundColor = ConsoleColor.Green; break;

            }

            return " " + Convert.ToString(char.ToUpper(Convert.ToChar(SeededWith[0]))) + " ";
        }
    }
}

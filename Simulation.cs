using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology_Sim
{

    internal class Simulation
    {
        static Random rnd = new Random();

        public string[] tileStates = { "wet", "ruined", "dry" };
        public string[] seeds = { "corn", "potato", "tomato", "nothing" };
        public DateTime Time { get; private set; } = DateTime.MinValue;

        public List<Tile> Tiles { get; private set; } = new List<Tile>();
        public List<Weather> Weathers { get; private set; } = [new Weather("Wind"), new Weather("Thunderstorm"), new Weather("Rain"), new Weather("Snow"), new Weather("Sunny weather")];

        public int Size { get; }

        public Simulation(int size)
        {
            Size = size;
            for (int i = 0; i < size * size; i++)
            {
                Tiles.Add(new Tile());
            }
        }

        public void RandomizeTiles()
        {
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].State = tileStates[rnd.Next(tileStates.Length)];
                Tiles[i].Seed = seeds[rnd.Next(seeds.Length)];
            }
        }

        public void Cast(Weather weather)
        {
            string[] snow = { "nothing", "ruined" };
            string[] thunder = { "wet", "ruined" };

            for (int i = 0; i < Tiles.Count; i++)
            {
                if (Tiles[i].Seed == "nothing" || Tiles[i].State == "ruined") continue;
                else if (Tiles[i].Chance!)
                {
                    switch (weather.Name)
                    {
                        case "Rain": Tiles[i].State = "wet"; break;
                        case "Snow": Tiles[i].Seed = snow[rnd.Next(2)]; break;
                        case "Sunny weather": Tiles[i].State = "dry"; break;
                        case "Thunderstorm": Tiles[i].State = thunder[rnd.Next(2)]; break;
                        case "Wind": Tiles[i].State = "ruined"; break;
                    }
                }
            }
        }
    }
}
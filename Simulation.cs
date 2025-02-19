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

        public string[] tileStates = { "wet", "snow", "dry" };
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
                Tiles[i].Temperature = rnd.Next(20, 30);
            }
        }

        public void Cast(Weather weather)
        {
            for (int i = 0; i < Tiles.Count; i++)
            {
                if (Tiles[i].Changeable)
                {
                    switch (weather.Name)
                    {
                        case "Rain": Tiles[i].State = "wet"; Tiles[i].Temperature -= rnd.Next(10); break;
                        case "Snow": Tiles[i].State = "snow"; Tiles[i].Temperature -= rnd.Next(15); break;
                        case "Sunny weather": Tiles[i].State = "dry"; Tiles[i].Temperature += rnd.Next(5, 15); break;
                        case "Thunderstorm": Tiles[i].State = "wet"; Tiles[i].Temperature -= rnd.Next(20); break;
                        case "Wind": Tiles[i].Temperature -= rnd.Next(10, 20); break;
                    }
                    Tiles[i].Changeable = false;
                    return;
                }
            }
        }
    }
}